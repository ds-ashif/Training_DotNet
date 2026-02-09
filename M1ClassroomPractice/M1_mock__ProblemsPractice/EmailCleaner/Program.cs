/**
Q10. Email Cleaner - Trim + Lower + Replace
Customer emails arrive with extra spaces and mixed casing.
Requirements:
•	Trim spaces
•	Convert to lowercase
•	If domain is gmail.com, replace it with company.com
Task: Input raw email and print cleaned email. Example: '  GOpi.Suresh@GMAIL.com  ' -> 'gopi.suresh@company.com'.
**/

using System;
namespace EmailCleaner
{
    /// <summary>
    /// Cleans email input by trimming spaces,
    /// converting to lowercase, and replacing
    /// gmail.com with company.com.
    /// </summary>
    class Program
    {
        static void Main()
        {
            // Ask user to enter email
            Console.WriteLine("Enter Email Address");
            string email = Console.ReadLine();

            // Remove leading and trailing spaces
            // and convert email to lowercase
            email=email.Trim().ToLower();

            // Replace gmail domain with company domain
            // Replace returns a new string, so assign back
            if (email.Contains("gmail.com"))
            {
                email=email.Replace("gmail.com","company.com");
            }
            // Display cleaned email
            Console.WriteLine($"your email:{email}");


        }
    }
}