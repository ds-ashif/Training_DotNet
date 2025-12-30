using System;

namespace Questions
{
    /// <summary>Checks strong number.</summary>
    public class StrongNumber
    {
        public static void Main()
        {
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());
                int temp = number, sum = 0;

                while (temp > 0)
                {
                    int digit = temp % 10;
                    int fact = 1;

                    for (int i = 1; i <= digit; i++)
                        fact *= i;

                    sum += fact;
                    temp /= 10;
                }

                Console.WriteLine(sum == number ? "Strong" : "Not Strong");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
    }
}
