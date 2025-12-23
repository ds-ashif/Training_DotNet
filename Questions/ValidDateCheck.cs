using System;

namespace Questions
{
    /// <summary>Validates calendar date.</summary>
    public class ValidDateCheck
    {
        public static void Main()
        {
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());

            bool leap = year % 400 == 0 || (year % 4 == 0 && year % 100 != 0);
            int[] days = { 31, leap ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (month >= 1 && month <= 12 && day >= 1 && day <= days[month - 1])
                Console.WriteLine("Valid Date");
            else
                Console.WriteLine("Invalid Date");
        }
    }
}
