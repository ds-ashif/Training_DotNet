using System;
using System.Collections.Generic;

namespace RestaurantMenuManagementSystem
{
    /// <summary>
    /// Handles menu operations including adding items,
    /// grouping by category, vegetarian filtering,
    /// and price calculations.
    /// </summary>
    class MenuManager
    {
        #region Fields

        /// <summary>
        /// Stores all menu items.
        /// </summary>
        
        private List<MenuItem> Menu = new List<MenuItem>();
        #endregion

        #region Add Menu Item

        /// <summary>
        /// Adds a new menu item after validating price.
        /// </summary>
        /// <param name="name">Item name</param>
        /// <param name="category">Food category</param>
        /// <param name="price">Item price (must be greater than 0)</param>
        /// <param name="isVeg">Indicates vegetarian item</param>

        public void AddMenuItem(string name, string category, double price, bool isVeg)
        {
            // Validate price
            if (price <= 0)
            {
                Console.WriteLine("Price must be greater than 0.");
                return;
            }
            
            Menu.Add(new MenuItem{ItemName = name, Category = category, Price = price, IsVegetarian = isVeg});
            
        }
        #endregion

        #region Group Items by Category

        /// <summary>
        /// Groups menu items based on category.
        /// </summary>
        /// <returns>Dictionary grouped by category</returns>

        public Dictionary<string, List<MenuItem>> GroupItemsByCategory()
        {
            Dictionary<string,List<MenuItem>> grouped = new Dictionary<string, List<MenuItem>>();

            foreach(var menu in Menu){
                if (!grouped.ContainsKey(menu.Category))
                {
                    grouped[menu.Category] = new List<MenuItem>();
                }
                grouped[menu.Category].Add(menu);
            }
            return grouped;
        }
        #endregion

        #region Vegetarian Items

        /// <summary>
        /// Returns all vegetarian menu items.
        /// </summary>

        public List<MenuItem> GetVegetarianItems()
        {
            List<MenuItem> OnlyVeg = new List<MenuItem>();
            foreach(var menu in Menu)
            {
                if (menu.IsVegetarian)
                {
                    OnlyVeg.Add(menu);
                }
            }
            return OnlyVeg;
        }
        #endregion

        #region Average Price Calculation

        /// <summary>
        /// Calculates average price of items in a category.
        /// </summary>
        /// <param name="category">Category name</param>
        /// <returns>Average price</returns>

        public double CalculateAveragePriceByCategory(string category)
        {
            double total=0;
            int count =0;
            if(count==0) return 0;

            foreach(var menu in Menu)
            {
                if(menu.Category == category)
                {
                    total += menu.Price;
                    count++;
                }
            }
            if (count == 0) return 0;
            return total/count;
        }
        #endregion

    }

}