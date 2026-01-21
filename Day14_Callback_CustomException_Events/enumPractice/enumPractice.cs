using System;

namespace enumPractice
{
    #region Enum Definition

    /// <summary>
    /// Represents the days of the week as a custom enumeration.
    /// Each value is automatically assigned an integer starting from 0.
    /// </summary>
    public enum DaysOfWeek
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    #endregion

    #region Program

    /// <summary>
    /// Demonstrates usage of a custom enum and iterating through its values.
    /// </summary>
    public class enumPractice
    {
        /// <summary>
        /// Application entry point.
        /// </summary>
        public static void Main()
        {
            // Assign a value from the DaysOfWeek enum
            DaysOfWeek today = DaysOfWeek.Wednesday;

            // Display the current day
            Console.WriteLine($"Today is: {today}");

            Console.WriteLine("\nAll days with their numeric values:");

            // Loop through all enum values using Enum.GetValues
            foreach (DaysOfWeek day in Enum.GetValues(typeof(DaysOfWeek)))
            {
                // Casting enum to int shows its underlying numeric value
                Console.WriteLine($"Day: {day}, Numeric Value: {(int)day}");
            }
        }
    }

    #endregion
}
