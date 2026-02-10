// Scenario 1: E-Commerce Inventory System

using System;
using System.Collections.Generic;

// Base product interface
namespace InventorySystem
{
    public interface IProduct
    {
        int Id { get; }
        string Name { get; }
        decimal Price { get; set; } 
        Category Category { get; }
    }

    public enum Category { Electronics, Clothing, Books, Groceries }

    // 1. Create a generic repository for products
    public class ProductRepository<T> where T : class, IProduct
    {
        private List<T> _products = new List<T>();

        // TODO: Implement method to add product with validation
        public void AddProduct(T product)
        {
            // Rule: Product ID must be unique
            // Rule: Price must be positive
            // Rule: Name cannot be null or empty
            // Add to collection if validation passes
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            foreach (var p in _products)
            {
                if (p.Id == product.Id)
                {
                    throw new InvalidOperationException("Product id must be unique");
                }
            }

            if (product.Price <= 0)
            {
                throw new ArgumentException("Price must be Positive");
            }

            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new ArgumentException("Name cannot be empty.");
            }

            _products.Add(product);
        }

        // TODO: Create method to find products by predicate
        public IEnumerable<T> FindProducts(Func<T, bool> predicate)
        {
            // Should return filtered products
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            List<T> result = new List<T>();

            foreach (var p in _products)
            {
                if (predicate(p)) result.Add(p);
            }

            return result;
        }

        // TODO: Calculate total inventory value
        public decimal CalculateTotalValue()
        {
            // Return sum of all product prices
            decimal sum = 0;

            foreach (var item in _products)
            {
                sum += item.Price;
            }

            return sum;
        }
    }

    // 2. Specialized electronic product
    public class ElectronicProduct : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category => Category.Electronics;
        public int WarrantyMonths { get; set; }
        public string Brand { get; set; }
    }

    // Extra product types used later
    public class BookProduct : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category => Category.Books;
    }

    public class ClothingProduct : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category => Category.Clothing;
    }

    // 3. Create a discounted product wrapper
    public class DiscountedProduct<T> where T : IProduct
    {
        private T _product;
        private decimal _discountPercentage;

        public DiscountedProduct(T product, decimal discountPercentage)
        {
            // TODO: Initialize with validation
            // Discount must be between 0 and 100
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            if (discountPercentage < 0 || discountPercentage > 100)
            {
                throw new ArgumentException("Discount must be between 0 and 100.");
            }

            _product = product;
            _discountPercentage = discountPercentage;
        }

        // TODO: Implement calculated price with discount
        public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);

        // TODO: Override ToString to show discount details
        public override string ToString()
        {
            return _product.Name +
                        " | Original: " + _product.Price +
                       " | Discount: " + _discountPercentage + "%" +
                       " | Final: " + DiscountedPrice;
        }
    }

    // 4. Inventory manager with constraints
    public class InventoryManager
    {
        // TODO: Create method that accepts any IProduct collection
        public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
        {
            // a) Print all product names and prices
            // b) Find the most expensive product
            // c) Group products by category
            // d) Apply 10% discount to Electronics over $500

            List<T> list = new List<T>();

            foreach (var item in products)
            {
                list.Add(item);
            }

            Console.WriteLine("\n--- Product List ---");
            foreach (var item in list)
            {
                Console.WriteLine(item.Name + " - " + item.Price);
            }

            T mostExpensive = default(T);
            decimal maxPrice = -1;

            foreach (var item in list)
            {
                if (item.Price > maxPrice)
                {
                    maxPrice = item.Price;
                    mostExpensive = item;
                }
            }

            if (mostExpensive != null)
            {
                Console.WriteLine("\nMost Expensive: " + mostExpensive.Name);
            }

            // Group by category
            Console.WriteLine("\n--- Grouped by Category ---");

            Dictionary<Category, List<T>> groups = new Dictionary<Category, List<T>>();

            foreach (var item in list)
            {
                if (!groups.ContainsKey(item.Category))
                {
                    groups[item.Category] = new List<T>();
                }
                groups[item.Category].Add(item);
            }

            foreach (var pair in groups)
            {
                Console.WriteLine(pair.Key);
                foreach (var item in pair.Value)
                {
                    Console.WriteLine(" " + item.Name);
                }
            }

            // Discount electronics > 500
            Console.WriteLine("\n--- Discounts Applied ---");

            foreach (var item in list)
            {
                if (item.Category == Category.Electronics && item.Price > 500)
                {
                    var discount = new DiscountedProduct<IProduct>(item, 10);
                    Console.WriteLine(discount);
                }
            }
        }

        // TODO: Implement bulk price update with delegate
        public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster)
            where T : IProduct
        {
            // Apply priceAdjuster to each product
            // Handle exceptions gracefully

            foreach (var product in products)
            {
                try
                {
                    decimal newPrice = priceAdjuster(product);

                    if (newPrice <= 0)
                    {
                        throw new ArgumentException("Invalid price result.");
                    }

                    product.Price = newPrice;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        "Price update failed for " +
                        product.Name + ": " + ex.Message);
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {

            var electronicsRepo = new ProductRepository<ElectronicProduct>();

            var p1 = new ElectronicProduct
            {
                Id = 1,
                Name = "Gaming Laptop",
                Price = 80000,
                Brand = "Alienware",
                WarrantyMonths = 24
            };

            var p2 = new ElectronicProduct
            {
                Id = 2,
                Name = "Smartphone",
                Price = 900,
                Brand = "Samsung",
                WarrantyMonths = 12
            };

            electronicsRepo.AddProduct(p1);
            electronicsRepo.AddProduct(p2);

            Console.WriteLine("Products added successfully.");

            Console.WriteLine("\nSamsung Products:");

            var samsungProducts =
                electronicsRepo.FindProducts(p => p.Brand == "Samsung");

            foreach (var item in samsungProducts)
                Console.WriteLine(item.Name);

            var discountedLaptop =
                new DiscountedProduct<ElectronicProduct>(p1, 15);

            Console.WriteLine("\nDiscount Demo:");
            Console.WriteLine(discountedLaptop);

            Console.WriteLine("\nTotal Value BEFORE discount:");
            Console.WriteLine(electronicsRepo.CalculateTotalValue());

            var mixedProducts = new List<IProduct>
        {
            p1,
            p2,
            new BookProduct { Id = 3, Name = "Clean Code", Price = 40 },
            new ClothingProduct { Id = 4, Name = "Jacket", Price = 120 },
            new BookProduct { Id = 5, Name = "Design Patterns", Price = 55 }
        };

            var manager = new InventoryManager();
            manager.ProcessProducts(mixedProducts);

            manager.UpdatePrices(mixedProducts, p => p.Price * 1.05m);

            Console.WriteLine("\nAfter 5% price increase:");
            foreach (var p in mixedProducts)
                Console.WriteLine(p.Name + " - " + p.Price);
        }
    }
}
