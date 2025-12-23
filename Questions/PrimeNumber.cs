using System;

namespace Questions
{
    /// <summary>Checks prime number.</summary>
    public class PrimeNumber
    {
        public static void Main()
        {
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());
                bool isPrime = true;

                if (number <= 1)
                    isPrime = false;
                else
                {
                    for (int i = 2; i <= number / 2; i++)
                    {
                        if (number % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                }

                Console.WriteLine(isPrime ? "Prime" : "Not Prime");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
    }
}
