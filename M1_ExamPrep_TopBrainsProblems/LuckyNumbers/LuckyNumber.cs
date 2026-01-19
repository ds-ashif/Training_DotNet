using System;

namespace LuckyNumbers
{
    /// <summary>
    /// Contains logic to identify and count Lucky Numbers.
    /// </summary>
    public class LuckyNumber
    {
        #region Helper Methods

        /// <summary>
        /// Determines whether a given number is prime.
        /// </summary>
        /// <param name="n">Number to check</param>
        /// <returns>True if prime, otherwise false</returns>
        public static bool IsPrime(int n)
        {
            if (n <= 1)
                return false;

            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Calculates the sum of digits of a number.
        /// </summary>
        /// <param name="n">Input number</param>
        /// <returns>Sum of digits</returns>
        public static int DigitSum(int n)
        {
            int sum = 0;

            while (n != 0)
            {
                sum += n % 10;
                n /= 10;
            }

            return sum;
        }

        /// <summary>
        /// Checks whether a number is a Lucky Number.
        /// </summary>
        /// <param name="n">Number to evaluate</param>
        /// <returns>True if Lucky Number, otherwise false</returns>
        public static bool IsLucky(int n)
        {
            if (IsPrime(n))
                return false;

            int nSum = DigitSum(n);
            int nSquare = n * n;
            int nSquareSum = DigitSum(nSquare);

            return nSquareSum == nSum * nSum;
        }

        #endregion

        #region Program Entry Point

        /// <summary>
        /// Program entry point.
        /// Reads input range and prints count of Lucky Numbers.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Enter starting number:");
            int m = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter ending number:");
            int n = int.Parse(Console.ReadLine()!);

            int totalLuckyNumbers = 0;

            for (int i = m; i <= n; i++)
            {
                if (IsLucky(i))
                {
                    totalLuckyNumbers++;
                }
            }

            Console.WriteLine(
                $"Total Lucky Numbers between {m} and {n}: {totalLuckyNumbers}"
            );
        }

        #endregion
    }
}
