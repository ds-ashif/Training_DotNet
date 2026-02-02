using System;
using System.Collections.Generic;

namespace BikeRentals
{
    /// <summary>
    /// Entry point of Bike Rental application.
    /// Provides menu-driven interaction for bike operations.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Stores bike records using unique integer keys.
        /// </summary>
        public static SortedDictionary<int, Bike> bikeDetails =
            new SortedDictionary<int, Bike>();

        /// <summary>
        /// Application execution starts here.
        /// Handles menu operations for adding and grouping bikes.
        /// </summary>
        static void Main()
        {
            BikeUtility utility = new BikeUtility();
            int choice;

            do
            {
                // Display menu options
                Console.WriteLine("1. Add Bike Details");
                Console.WriteLine("2. Group Bikes By Brand");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                Console.WriteLine("Enter your choice");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Collect bike details from user
                        Console.WriteLine("Enter the model");
                        string model = Console.ReadLine();

                        Console.WriteLine("Enter the brand");
                        string brand = Console.ReadLine();

                        Console.WriteLine("Enter the price per day");
                        int price = int.Parse(Console.ReadLine());

                        // Add bike to collection
                        utility.AddBikeDetails(bikeDetails, model, brand, price);

                        Console.WriteLine("Bike details added successfully");
                        Console.WriteLine();
                        break;

                    case 2:
                        // Group bikes by brand
                        var groupedBikes = utility.GroupBikesByBrand(bikeDetails);

                        // Display grouped bikes
                        foreach (var entry in groupedBikes)
                        {
                            Console.WriteLine(entry.Key);

                            foreach (var bike in entry.Value)
                            {
                                Console.WriteLine(bike.Model);
                            }

                            Console.WriteLine();
                        }
                        break;

                    case 3:
                        // Exit option
                        break;
                }

            } while (choice != 3);
        }
    }
}
