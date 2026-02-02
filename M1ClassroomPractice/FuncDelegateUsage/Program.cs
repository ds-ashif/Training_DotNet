using System;
using System.Collections.Generic;

namespace FuncDelegateUsage
{
    /// <summary>
    /// Program class demonstrating the usage of Func delegate.
    /// </summary>
    class Program
    {

        /// <summary>
        /// Calculates the total price using the provided Func delegate.
        /// </summary>
    
        public static decimal CalculateTotal<T>(T item, int qty , Func<T,int,decimal> priceCalculator)
        {
            return priceCalculator(item, qty);
        }

        /// <summary>
        /// Main method - entry point of the program.
        /// </summary>
        public static void Main()
        {
            // Example 1: Calculating total price for laptops
            var laptopPrice= CalculateTotal("Laptop", 5, (item, qty)=>{
                decimal unitPrice = 86000m;
                return unitPrice * qty;
            });
            Console.WriteLine($"Total price for laptops: {laptopPrice}");
            Console.WriteLine("---------------------------------------------------");

            // Example 2: Calculating total price for groceries
            var GroceryPrice = CalculateTotal("Grocery", 10, (item, qty) =>
            {
                decimal unitPrice = 140.45m;
                return unitPrice * qty;
            });
            Console.WriteLine($"Total price for groceries: {GroceryPrice}");
            Console.WriteLine("---------------------------------------------------");
        }

    }
}
