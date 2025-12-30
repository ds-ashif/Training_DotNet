using System;

namespace Questions
{
    /// <summary>Prints first N Fibonacci terms.</summary>
    public class FibonacciSeries
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Enter nth number to get first nth terms of series:");
                int num = Convert.ToInt32(Console.ReadLine());

                int prev2 = 0;
                int prev1 = 1;
                Console.Write($"{prev2} {prev1} ");

                int current;

                for (int i = 2; i < num; i++)
                {
                    current = prev2 + prev1;
                    Console.Write($"{current} ");
                    prev2 = prev1;
                    prev1 = current;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
    }
}
