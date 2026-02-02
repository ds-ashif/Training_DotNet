namespace BikeRentals
{
    /// <summary>
    /// Represents a bike available for rental in the BikeRentals system.
    /// Contains basic information required for booking and pricing.
    /// </summary>
    public class Bike
    {
        /// <summary>
        /// Gets or sets the model name of the bike.
        /// Example: "Classic 350", "R15", etc.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the brand/manufacturer of the bike.
        /// Example: "Royal Enfield", "Yamaha", etc.
        /// </summary>

        public string Brand { get; set; }

         /// <summary>
        /// Gets or sets the rental price per day for the bike.
        /// Value is represented in local currency.
        /// </summary>
        public int PricePerDay { get; set; }
    }
}
