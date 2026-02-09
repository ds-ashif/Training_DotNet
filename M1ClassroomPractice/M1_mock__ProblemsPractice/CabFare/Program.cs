using System;

namespace CabFare
{
    /// <summary>
    /// Base Cab class representing a generic cab.
    /// Contains a virtual method to calculate fare.
    /// </summary>
    public class Cab
    {
        /// <summary>
        /// Calculates fare for given distance.
        /// This method will be overridden in child classes.
        /// </summary>
        /// <param name="km">Distance travelled in kilometers</param>
        /// <returns>Fare amount</returns>
        public virtual double CalculateFare(int km)
        {
            return 0;
        }
    }

    /// <summary>
    /// Mini cab fare calculation.
    /// Fare = km * 12
    /// </summary>
    class Mini : Cab
    {
        public override double CalculateFare(int km)
        {
            return km * 12;
        }
    }

    /// <summary>
    /// Sedan cab fare calculation.
    /// Fare = km * 15 + 50 (base charge)
    /// </summary>
    class Sedan : Cab
    {
        public override double CalculateFare(int km)
        {
            return km * 15 + 50;
        }
    }

    /// <summary>
    /// SUV cab fare calculation.
    /// Fare = km * 18 + 100 (base charge)
    /// </summary>
    class SUV : Cab
    {
        public override double CalculateFare(int km)
        {
            return km * 18 + 100;
        }
    }

    /// <summary>
    /// Entry point of the Cab Fare application.
    /// Demonstrates runtime polymorphism.
    /// </summary>
    class Program
    {
        static void Main()
        {
            // Ask user to select cab type
            Console.WriteLine("Enter cab type (Mini/Sedan/SUV):");
            string cabType = Console.ReadLine().ToLower();

            // Read travel distance
            Console.WriteLine("Enter distance in km:");
            int km = int.Parse(Console.ReadLine());

            // Base class reference for runtime polymorphism
            Cab cab;

            // Create object based on user input
            switch (cabType)
            {
                case "mini":
                    cab = new Mini();
                    break;

                case "sedan":
                    cab = new Sedan();
                    break;

                default:
                    cab = new SUV();
                    break;
            }

            // Fare calculation using polymorphism
            double fare = cab.CalculateFare(km);

            // Display final fare
            Console.WriteLine($"Total Fare: Rs. {fare}");
        }
    }
}
