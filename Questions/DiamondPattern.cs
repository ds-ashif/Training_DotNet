using System;

namespace Questions
{
    /// <summary>Prints diamond pattern.</summary>
    public class DiamondPattern
    {
        public static void Main()
        {
            try
            {
                int n = Convert.ToInt32(Console.ReadLine());

                for (int i = 1; i <= n; i++)
                {
                    for (int s = i; s < n; s++) Console.Write(" ");
                    for (int j = 1; j <= 2 * i - 1; j++) Console.Write("*");
                    Console.WriteLine();
                }

                for (int i = n - 1; i >= 1; i--)
                {
                    for (int s = n; s > i; s--) Console.Write(" ");
                    for (int j = 1; j <= 2 * i - 1; j++) Console.Write("*");
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
    }
}
