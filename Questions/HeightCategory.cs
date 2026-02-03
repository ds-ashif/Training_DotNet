using System;

namespace Questions
{
    /// <summary>
    /// Determines the height category of a person based on height in centimeters.
    /// </summary>
    public class HeightCategory
    {
        /// <summary>
        /// Application entry point.
        /// Reads height input and displays the category.
        /// </summary>
        public static void Main()
        {
            #region Input

            // Read height in centimeters from user
            Console.WriteLine("Enter height in centimeters:");
            int heightCm = int.Parse(Console.ReadLine());

            #endregion

            #region Height Classification Logic


            if (heightCm < 150)
            {
                Console.WriteLine("Short");
            }
            else if (heightCm < 180)
            {
                Console.WriteLine("Average");
            }
            else
            {
                Console.WriteLine("Tall");
            }

            #endregion
        }
    }
}
