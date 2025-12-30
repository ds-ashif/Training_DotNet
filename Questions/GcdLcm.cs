using System;

namespace Questions
{
    /// <summary>Finds GCD and LCM.</summary>
    public class GcdLcm
    {
        public static void Main()
        {
            try
            {
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                int x = a, y = b;

                while (y != 0)
                {
                    int temp = y;
                    y = x % y;
                    x = temp;
                }

                int gcd = x;
                int lcm = (a * b) / gcd;

                Console.WriteLine(gcd);
                Console.WriteLine(lcm);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
    }
}
