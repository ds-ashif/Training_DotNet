using System;

namespace RestaurantMenuManagementSystem
{
    /// <summary>
    /// Application entry point demonstrating menu management.
    /// </summary>
    class Program
    {
        static void Main()
        {
            MenuManager manager = new MenuManager();

            #region Add Sample Items

            manager.AddMenuItem("Spring Rolls", "Appetizer", 150, true);
            manager.AddMenuItem("Chicken Curry", "Main Course", 350, false);
            manager.AddMenuItem("Paneer Butter Masala", "Main Course", 320, true);
            manager.AddMenuItem("Ice Cream", "Dessert", 120, true);

            #endregion

            #region Display Grouped Menu

            var grouped = manager.GroupItemsByCategory();

            Console.WriteLine("Menu by Category:");
            foreach (var group in grouped)
            {
                Console.WriteLine($"\n{group.Key}:");
                foreach (var item in group.Value){
                    Console.WriteLine($"{item.ItemName} - {item.Price}");
                }
            }

            #endregion

            #region Vegetarian Menu

            Console.WriteLine("\nVegetarian Items:");
            var vegItems = manager.GetVegetarianItems();

            foreach (var item in vegItems){
                Console.WriteLine(item.ItemName);
            }

            #endregion

            #region Average Price

            Console.WriteLine("\nAverage Price (Main Course): " + manager.CalculateAveragePriceByCategory("Main Course"));

            #endregion
        }
    }
}
