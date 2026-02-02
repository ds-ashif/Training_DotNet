using System.Collections.Generic;

namespace BikeRentals
{
    /// <summary>
    /// Provides utility operations for managing bike rental data.
    /// Includes functionality for adding bikes and grouping them by brand.
    /// </summary>
    public class BikeUtility
    {
        /// <summary>
        /// Adds a new bike entry into the bike collection.
        /// A unique key is generated automatically based on current count.
        /// </summary>
        /// <param name="bikeDetails">Dictionary storing bike records.</param>
        /// <param name="model">Model name of the bike.</param>
        /// <param name="brand">Brand name of the bike.</param>
        /// <param name="pricePerDay">Rental price per day.</param>
        public void AddBikeDetails(
            SortedDictionary<int, Bike> bikeDetails,
            string model,
            string brand,
            int pricePerDay)
        {
            // Generate next key based on existing count
            int key = bikeDetails.Count + 1;

            // Create bike object
            Bike bike = new Bike
            {
                Model = model,
                Brand = brand,
                PricePerDay = pricePerDay
            };

            // Add bike to dictionary
            bikeDetails.Add(key, bike);
        }

        /// <summary>
        /// Groups bikes by brand name.
        /// Each brand contains a list of bikes belonging to it.
        /// </summary>
        /// <param name="bikeDetails">Dictionary containing bike data.</param>
        /// <returns>
        /// A dictionary where key is brand and value is list of bikes.
        /// </returns>
        public SortedDictionary<string, List<Bike>> GroupBikesByBrand(
            SortedDictionary<int, Bike> bikeDetails)
        {
            // Dictionary storing grouped bikes
            SortedDictionary<string, List<Bike>> groupedBikes =
                new SortedDictionary<string, List<Bike>>();

            // Iterate through all bikes
            foreach (Bike bike in bikeDetails.Values)
            {
                // Create brand entry if not present
                if (!groupedBikes.ContainsKey(bike.Brand))
                {
                    groupedBikes[bike.Brand] = new List<Bike>();
                }

                // Add bike to corresponding brand group
                groupedBikes[bike.Brand].Add(bike);
            }

            return groupedBikes;
        }
    }
}
