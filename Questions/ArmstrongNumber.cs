using System;

namespace Questions
{
    /// <summary>Checks Armstrong number.</summary>
    public class ArmstrongNumber
    {
        public static void Main()
        {
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());
                int temp = number, digits = 0, sum = 0;

                while (temp > 0)
                {
                    digits++;
                    temp /= 10;
                }

                temp = number;
                while (temp > 0)
                {
                    int digit = temp % 10;
                    sum += (int)Math.Pow(digit, digits);
                    temp /= 10;
                }

                Console.WriteLine(sum == number ? "Armstrong" : "Not Armstrong");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
    }
}
