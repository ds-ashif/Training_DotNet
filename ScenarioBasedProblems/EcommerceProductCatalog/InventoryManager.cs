using System;
using System.Collections.Generic;

namespace EcommerceProductCatalog
{
    /// <summary>
    /// Handles product catalog and stock management.
    /// </summary>
    public class InventoryManager
    {
        #region Fields

        /// <summary>
        /// Stores all products.
        /// </summary>
        private List<Product> products = new List<Product>();

        /// <summary>
        /// Counter used for generating product codes.
        /// </summary>
        private int productCounter = 1;

        #endregion

        #region Add Product

        /// <summary>
        /// Adds product with auto-generated product code.
        /// </summary>
        /// <param name="name">Product name</param>
        /// <param name="category">Product category</param>
        /// <param name="price">Product price</param>
        /// <param name="stock">Initial stock quantity</param>
        public void AddProduct(string name, string category, double price, int stock)
        {
            string code = $"P{productCounter:D3}";
            productCounter++;

            products.Add(new Product{ ProductCode = code, ProductName = name, Category = category, Price = price, StockQuantity = stock});
        }

        #endregion

        #region Group Products by Category

        /// <summary>
        /// Groups products based on category.
        /// </summary>
        /// <returns>Sorted dictionary grouped by category</returns>
        public SortedDictionary<string, List<Product>> GroupProductsByCategory()
        {
            SortedDictionary<string, List<Product>> grouped = new SortedDictionary<string, List<Product>>();

            foreach (var product in products)
            {
                if (!grouped.ContainsKey(product.Category)){
                    grouped[product.Category] = new List<Product>();
                }
                grouped[product.Category].Add(product);
            }

            return grouped;
        }

        #endregion

        #region Update Stock

        /// <summary>
        /// Updates stock after sale or adjustment.
        /// Returns false if insufficient stock.
        /// </summary>
        /// <param name="productCode">Product code</param>
        /// <param name="quantity">Quantity to deduct</param>
        /// <returns>True if update successful</returns>
        public bool UpdateStock(string productCode, int quantity)
        {
            foreach (var product in products)
            {
                if (product.ProductCode == productCode)
                {
                    if (product.StockQuantity < quantity){
                        return false;
                    }
                    product.StockQuantity -= quantity;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Filter Products by Price

        /// <summary>
        /// Returns products priced below or equal to given value.
        /// </summary>
        /// <param name="maxPrice">Maximum price allowed</param>
        /// <returns>List of products under price</returns>
        public List<Product> GetProductsBelowPrice(double maxPrice)
        {
            List<Product> result = new List<Product>();

            foreach (var product in products)
            {
                if (product.Price <= maxPrice){
                    result.Add(product);
                }
            }

            return result;
        }

        #endregion

        #region Category Stock Summary

        /// <summary>
        /// Calculates total stock available per category.
        /// </summary>
        /// <returns>Dictionary with category and stock totals</returns>
        public Dictionary<string, int> GetCategoryStockSummary()
        {
            Dictionary<string, int> summary =
                new Dictionary<string, int>();

            foreach (var product in products)
            {
                if (!summary.ContainsKey(product.Category)){
                    summary[product.Category] = 0;
                }

                summary[product.Category] += product.StockQuantity;
            }

            return summary;
        }

        #endregion
    }
}
