using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MiniOrderSystem
{
    #region Exceptions

    /// <summary>
    /// Base exception type for the order system.
    /// All domain-related errors inherit from this.
    /// </summary>
    public class OrderSystemException : Exception
    {
        public OrderSystemException(string message) : base(message) { }
    }

    /// <summary>
    /// Thrown when product stock is insufficient.
    /// </summary>
    public class OutOfStockException : OrderSystemException
    {
        public OutOfStockException(string message) : base(message) { }
    }

    /// <summary>
    /// Thrown when coupon validation fails.
    /// </summary>
    public class CouponException : OrderSystemException
    {
        public CouponException(string message) : base(message) { }
    }

    #endregion

    #region Entities

    /// <summary>
    /// Represents a product stored in inventory.
    /// Includes thread-safe stock deduction.
    /// </summary>
    public class Product
    {
        /// <summary>Unique product id.</summary>
        public int Id { get; }

        /// <summary>Product display name.</summary>
        public string Name { get; }

        /// <summary>Unit price.</summary>
        public decimal Price { get; }

        /// <summary>Available stock count.</summary>
        public int Stock { get; private set; }

        /// <summary>
        /// Lock ensures atomic stock deduction.
        /// Prevents race conditions in concurrent orders.
        /// </summary>
        private readonly object _lock = new object();

        public Product(int id, string name, decimal price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        /// <summary>
        /// Deducts stock safely.
        /// Throws exception if stock insufficient.
        /// </summary>
        public void DeductStock(int quantity)
        {
            lock (_lock)
            {
                if (Stock < quantity) throw new OutOfStockException($"Insufficient stock for {Name}");

                Stock -= quantity;
            }
        }
    }

    /// <summary>
    /// Customer placing orders.
    /// </summary>
    public class Customer
    {
        public int Id { get; }
        public string Name { get; }

        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    /// <summary>
    /// Represents a product entry in cart/order.
    /// </summary>
    public class OrderItem
    {
        /// <summary>Selected product.</summary>
        public Product Product { get; }

        /// <summary>Quantity ordered.</summary>
        public int Quantity { get; }

        /// <summary>Total price for item.</summary>
        public decimal TotalPrice => Product.Price * Quantity;

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }

    /// <summary>
    /// Payment information for an order.
    /// </summary>
    public class Payment
    {
        /// <summary>Total amount paid.</summary>
        public decimal Amount { get; }

        /// <summary>Payment timestamp.</summary>
        public DateTime PaidAt { get; } = DateTime.UtcNow;

        public Payment(decimal amount)
        {
            Amount = amount;
        }
    }

    /// <summary>
    /// Final order entity after placement.
    /// </summary>
    public class Order
    {
        public string InvoiceNumber { get; }
        public Customer Customer { get; }
        public List<OrderItem> Items { get; }
        public decimal TotalAmount { get; }
        public Payment Payment { get; }

        public Order(string invoice,
                     Customer customer,
                     List<OrderItem> items,
                     decimal total,
                     Payment payment)
        {
            InvoiceNumber = invoice;
            Customer = customer;
            Items = items;
            TotalAmount = total;
            Payment = payment;
        }
    }

    #endregion

    #region Coupon Logic

    /// <summary>
    /// Coupon rule definition.
    /// Supports minimum order validation and discount application.
    /// </summary>
    public class Coupon
    {
        public string Code { get; }
        public decimal DiscountPercent { get; }
        public decimal MinimumOrderAmount { get; }

        public Coupon(string code,decimal discountPercent,decimal minAmount)
        {
            Code = code;
            DiscountPercent = discountPercent;
            MinimumOrderAmount = minAmount;
        }

        /// <summary>
        /// Applies discount after validating eligibility.
        /// </summary>
        public decimal Apply(decimal total)
        {
            if (total < MinimumOrderAmount) throw new CouponException("Order not eligible for coupon");

            decimal discount = total * DiscountPercent / 100;
            return total - discount;
        }
    }

    #endregion

    #region Cart Service

    /// <summary>
    /// Temporary shopping cart.
    /// Holds items before order placement.
    /// </summary>
    public class Cart
    {
        private readonly List<OrderItem> _items = new();

        /// <summary>
        /// Adds product to cart.
        /// </summary>
        public void AddToCart(Product product, int qty)
        {
            if (qty <= 0) throw new OrderSystemException("Quantity must be positive");

            _items.Add(new OrderItem(product, qty));
        }

        /// <summary>
        /// Returns cart items copy.
        /// </summary>
        public List<OrderItem> GetItems() => _items.ToList();

        /// <summary>
        /// Calculates cart total.
        /// </summary>
        public decimal GetTotal() => _items.Sum(i => i.TotalPrice);

        /// <summary>
        /// Clears cart after order success.
        /// </summary>
        public void Clear() => _items.Clear();
    }

    #endregion

    #region Order Service

    /// <summary>
    /// Coordinates complete order placement workflow.
    /// </summary>
    public class OrderService
    {
        /// <summary>
        /// Invoice counter seed.
        /// Thread-safe increment ensures uniqueness.
        /// </summary>
        private static int _invoiceCounter = 1000;

        /// <summary>
        /// Generates unique invoice numbers.
        /// </summary>
        private string GenerateInvoice()
        {
            return $"INV-{Interlocked.Increment(ref _invoiceCounter)}";
        }

        /// <summary>
        /// Places order end-to-end.
        /// Steps:
        /// 1. Validate cart
        /// 2. Validate stock
        /// 3. Deduct stock atomically
        /// 4. Apply coupon
        /// 5. Process payment
        /// 6. Generate invoice
        /// </summary>
        public Order PlaceOrder(Customer customer, Cart cart, Coupon coupon = null)
        {
            var items = cart.GetItems();

            if (!items.Any()) throw new OrderSystemException("Cart is empty");

            // Validate stock availability first
            foreach (var item in items)
            {
                if (item.Product.Stock < item.Quantity) throw new OutOfStockException($"Not enough stock for {item.Product.Name}");
            }

            // Deduct stock atomically
            foreach (var item in items)
            {
                item.Product.DeductStock(item.Quantity);
            }

            // Calculate total
            decimal total = cart.GetTotal();

            // Apply coupon if provided
            if (coupon != null) total = coupon.Apply(total);

            // Payment simulation
            var payment = new Payment(total);

            // Generate invoice
            string invoice = GenerateInvoice();

            // Create order
            var order = new Order(invoice, customer, items, total, payment);

            // Clear cart after success
            cart.Clear();

            return order;
        }
    }

    #endregion

    #region Demo Program

    /// <summary>
    /// Application entry point.
    /// Demonstrates full workflow.
    /// </summary>
    class Program
    {
        static void Main()
        {
            try
            {
                var customer = new Customer(1, "Alice");

                var laptop = new Product(1, "Laptop", 50000, 5);
                var mouse = new Product(2, "Mouse", 500, 10);

                var cart = new Cart();

                // Add products to cart
                cart.AddToCart(laptop, 1);
                cart.AddToCart(mouse, 2);

                // Coupon setup
                var coupon = new Coupon("SALE10", 10, 1000);

                var orderService = new OrderService();

                // Place order
                var order = orderService.PlaceOrder(customer,cart,coupon);

                Console.WriteLine("Order placed successfully!");
                Console.WriteLine($"Invoice: {order.InvoiceNumber}");
                Console.WriteLine($"Total Paid: {order.TotalAmount}");
            }
            catch (OrderSystemException ex)
            {
                Console.WriteLine($"Order failed: {ex.Message}");
            }
        }
    }

    #endregion
}
