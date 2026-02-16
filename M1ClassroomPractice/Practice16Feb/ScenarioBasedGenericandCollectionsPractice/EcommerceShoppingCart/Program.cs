using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public abstract class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

}

public class ShoppingCart<T> where T : Product
{
    private Dictionary<T,int> _cartItems = new Dictionary<T, int>();

    // Add product to cart
    public void AddToCart(T product, int quantity)
    {
        // TODO: Add or update quantity in dictionary
        if (quantity <= 0) return;
        if (!_cartItems.ContainsKey(product))
        {
            _cartItems[product] = quantity;
        }
        else
        {
            _cartItems[product] +=quantity;
        }

    }

    // Calculate total with discount delegate
    public double CalculateTotal(Func<T, double, double> discountCalculator = null)
    {
        double total =0;
        foreach(var item in _cartItems)
        {
            double price = item.Key.Price * item.Value;
            if (discountCalculator != null){
                price = discountCalculator(item.Key, price);
            }
            total += price;
        }
        return total;
    }

    // Get top N expensive items using LINQ
    public List<T> GetTopExpensiveItems(int n)
    {
        // TODO: Use LINQ OrderByDescending and Take
        return _cartItems.OrderByDescending(i =>i.Key.Price).Take(n).Select(i => i.Key).ToList();
    }
}

// -------- TEST --------
class Electronics : Product { }
class Clothing : Product { }

class Program
{
    static void Main()
    {
        ShoppingCart<Electronics> cart = new();

        cart.AddToCart(
            new Electronics { Id = 1, Name = "Laptop", Price = 999.99 },
            1
        );

        cart.AddToCart(
            new Electronics { Id = 2, Name = "Mouse", Price = 29.99 },
            2
        );

        // Discount rule
        double total = cart.CalculateTotal(
            (product, price) => price > 100 ? price * 0.9 : price
        );

        Console.WriteLine($"Total: ${total:F2}");

        var topItems = cart.GetTopExpensiveItems(1);
        Console.WriteLine(topItems[0].Name); // Laptop
    }
}