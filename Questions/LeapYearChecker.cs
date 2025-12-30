using System;

namespace Questions
{
    /// <summary>Checks whether a year is leap.</summary>
    public class LeapYearChecker
    {
        public static void Main()
        {
            Console.Write("Enter a year: ");
            int year=Convert.ToInt32(Console.ReadLine());
            if(year%400==0 || (year%4==0 && year%100!=0)){
                Console.WriteLine($"{year} is a leap year.");
            }
            else{
                Console.WriteLine($"{year} is not a leap year.");
            }
        }
    }
}
