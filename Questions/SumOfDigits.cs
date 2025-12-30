using System;

namespace Questions
{
    /// <summary>Finds digital root.</summary>
    public class SumOfDigits
    {
        public static void Main()
        {
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());

                while (number >= 10)
                {
                    int sum = 0;
                    while (number > 0)
                    {
                        sum += number % 10;
                        number /= 10;
                    }
                    number = sum;
                }

                Console.WriteLine(number);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
    }
}
