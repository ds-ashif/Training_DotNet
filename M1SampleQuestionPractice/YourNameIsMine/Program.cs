using System;

namespace YourNameIsMine
{
    class Program
    {
        /// <summary>
        /// Checks if 'small' is a subsequence of 'large'.
        /// </summary>
        /// <param name="small"></param>
        /// <param name="large"></param>
        /// <returns></returns>
        public static bool IsSubsequence(string small, string large)
        {
            int i = 0, j = 0;

            while (i < small.Length && j < large.Length)
            {
                if (char.ToLower(small[i]) == char.ToLower(large[j]))
                    i++;
                j++;
            }
            return i == small.Length;
        }

        /// <summary>
        /// Validates that the name contains only letters and spaces.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsValidName(string name)
        {
            foreach (char c in name)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Calculates the compatibility score between two names.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static int CompatibilityScore(string s1, string s2)
        {
            int m = s1.Length;
            int n = s2.Length;

            int[,] dp = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
                dp[i, 0] = i;
            for (int j = 0; j <= n; j++)
                dp[0, j] = j;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (char.ToLower(s1[i - 1]) == char.ToLower(s2[j - 1]))
                        dp[i, j] = dp[i - 1, j - 1];
                    else
                        dp[i, j] = 1 + Math.Min(
                            dp[i - 1, j],          // delete
                            Math.Min(
                                dp[i, j - 1],      // insert
                                dp[i - 1, j - 1]   // substitute
                            )
                        );
                }
            }
            return dp[m, n];
        }

        /// <summary>
        /// The entry point of the application.
        /// Reads user input, validates names,
        /// </summary>

        public static void Main()
        {
            Console.WriteLine("Enter the man name");
            string manName = Console.ReadLine();

            Console.WriteLine("Enter the woman name");
            string womanName = Console.ReadLine();

            // Input validation
            bool manValid = IsValidName(manName);
            bool womanValid = IsValidName(womanName);

            // Handling invalid names
            if (!manValid && !womanValid)
            {
                Console.WriteLine($"Both {manName} and {womanName} are invalid names");
                return;
            }
            if (!manValid)
            {
                Console.WriteLine($"{manName} is an invalid name");
                return;
            }
            if (!womanValid)
            {
                Console.WriteLine($"{womanName} is an invalid name");
                return;
            }

            // Subsequence check
            string m = manName.Replace(" ", "");
            string w = womanName.Replace(" ", "");

            int compatibility = CompatibilityScore(m, w);

            if (IsSubsequence(m, w) || IsSubsequence(w, m) || compatibility <= 3)
            {
                Console.WriteLine($"{manName} and {womanName} are made for each other");
                Console.WriteLine("Compatibility Value is " + compatibility);
            }
            else
            {
                Console.WriteLine($"{manName} and {womanName} are not made for each other");
            }
        }
    }
}
