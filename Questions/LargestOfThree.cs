using System;

namespace Questions
{
    /// <summary>
    /// Provides functionality to determine the largest number among three user-provided integers.
    /// </summary>
    public class LargestOfThree
    {
        /// <summary>
        /// Application entry point.
        /// Reads three numbers from the console and prints the largest value.
        /// </summary>
        public static void Main()
        {
            #region Input Collection

            // Read first number
            Console.WriteLine("Enter num1: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            // Read second number
            Console.WriteLine("Enter num2: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            // Read third number
            Console.WriteLine("Enter num3: ");
            int num3 = Convert.ToInt32(Console.ReadLine());

            #endregion

            #region Largest Number Logic

            /*
             * Compare numbers using nested conditions.
             * First compare num1 and num2,
             * then compare the larger value with num3.
             */

            if (num1 >= num2)
            {
                if (num1 >= num3)
                    Console.WriteLine($"{num1} is largest");
                else
                    Console.WriteLine($"{num3} is largest");
            }
            else
            {
                if (num2 >= num3)
                    Console.WriteLine($"{num2} is largest");
                else
                    Console.WriteLine($"{num3} is largest");
            }

            #endregion
        }
    }
}
