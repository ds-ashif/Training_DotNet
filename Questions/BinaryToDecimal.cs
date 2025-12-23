using System;

namespace Questions
{
    /// <summary>Binary to decimal conversion.</summary>
    public class BinaryToDecimal
    {
        public static void Main()
        {
            try
            {
                int binary = Convert.ToInt32(Console.ReadLine());
                int decimalValue = 0, baseValue = 1;

                while (binary > 0)
                {
                    decimalValue += (binary % 10) * baseValue;
                    binary /= 10;
                    baseValue *= 2;
                }

                Console.WriteLine(decimalValue);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
    }
}
