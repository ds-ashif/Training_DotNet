using System;

namespace Questions
{
    /// <summary>Reverse and palindrome check.</summary>
    public class ReversePalindrome
    {
        public static void Main()
        {
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());
                int temp = number, reverse = 0;

                while (temp > 0)
                {
                    reverse = reverse * 10 + temp % 10;
                    temp /= 10;
                }

                Console.WriteLine(reverse);
                Console.WriteLine(reverse == number ? "Palindrome" : "Not Palindrome");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
    }
}
