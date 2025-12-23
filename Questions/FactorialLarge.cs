using System;
using System.Numerics;

namespace Questions
{
    /// <summary>Calculates factorial.</summary>
    public class FactorialLarge
    {
        public static void Main()
        {
            try
            {
                int n = Convert.ToInt32(Console.ReadLine());
                BigInteger fact = 1;

                for (int i = 1; i <= n; i++)
                    fact *= i;

                Console.WriteLine(fact);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
    }
}
