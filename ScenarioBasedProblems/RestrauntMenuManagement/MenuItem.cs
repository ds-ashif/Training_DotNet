using System;

namespace RestaurantMenuManagementSystem
{
    /// <summary>
    /// Represents a menu item in the restaurant.
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// Name of the menu item.
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Category of food (Appetizer/Main Course/Dessert).
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Price of the menu item.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Indicates whether the item is vegetarian.
        /// </summary>
        public bool IsVegetarian { get; set; }
    }
}
