using System;

namespace MultiplicationTable
{
    /// <summary>
    /// Generates and displays the multiplication table of a given number
    /// up to a specified limit.
    /// </summary>
    class Table
    {
        #region Program Entry Point

        /// <summary>
        /// Program entry point.
        /// Reads input from the user and prints the multiplication table.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Enter a number to generate its multiplication table:");
            int n = int.Parse(Console.ReadLine()!);

            Console.WriteLine(
                $"Enter the number up to which the multiplication table of {n} is to be generated:"
            );
            int upTo = int.Parse(Console.ReadLine()!);

            ///<summary>
            /// Multiplication table array that stores result at each iteration
            /// </summary>
            
            int[] table = new int[upTo];

            for (int i = 1; i <= upTo; i++)
            {
                table[i - 1] = n * i;
            }

            Console.WriteLine(
                $"Multiplication table of {n} up to {upTo} is:"
            );

            for (int i = 0; i < upTo; i++)
            {
                Console.Write($"{table[i]} ");
            }
        }

        #endregion
    }
}
