using System;

namespace EcommerceProductCatalog
{
    /// <summary>
    /// Entry point demonstrating catalog operations.
    /// </summary>
    class Program
    {
        static void Main()
        {
            InventoryManager manager = new InventoryManager();

            #region Add Products

            manager.AddProduct("Laptop", "Electronics", 60000, 10);
            manager.AddProduct("T-Shirt", "Clothing", 1200, 50);
            manager.AddProduct("Book", "Books", 500, 100);
            manager.AddProduct("Headphones", "Electronics", 2000, 25);

            #endregion

            #region Display Products by Category

            Console.WriteLine("Products by Category:");

            var grouped = manager.GroupProductsByCategory();
            foreach (var group in grouped)
            {
                Console.WriteLine($"\n{group.Key}:");
                foreach (var product in group.Value)
                    Console.WriteLine($"{product.ProductName} - {product.Price}");
            }

            #endregion

            #region Update Stock

            Console.WriteLine("\nUpdating Stock...");
            bool updated = manager.UpdateStock("P001", 2);
            Console.WriteLine(updated ? "Stock updated." : "Insufficient stock.");

            #endregion

            #region Products Under Budget

            Console.WriteLine("\nProducts Under 3000:");
            var budgetProducts = manager.GetProductsBelowPrice(3000);

            foreach (var p in budgetProducts)
                Console.WriteLine(p.ProductName);

            #endregion

            #region Stock Summary

            Console.WriteLine("\nStock Summary:");
            var summary = manager.GetCategoryStockSummary();

            foreach (var entry in summary)
                Console.WriteLine($"{entry.Key}: {entry.Value}");

            #endregion
        }
    }
}
