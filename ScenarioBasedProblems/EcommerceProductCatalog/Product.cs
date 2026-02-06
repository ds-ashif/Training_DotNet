using System;

namespace EcommerceProductCatalog
{
    /// <summary>
    /// Represents a product in the e-commerce catalog.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Unique auto-generated product code (P001, P002...).
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// Product display name.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Product category (Electronics, Clothing, Books, etc.).
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Product selling price.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Available stock quantity.
        /// </summary>
        public int StockQuantity { get; set; }
    }
}
