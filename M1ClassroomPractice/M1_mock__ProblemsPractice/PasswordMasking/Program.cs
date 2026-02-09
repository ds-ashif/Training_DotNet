/**
Q9. Password Masking - String Manipulation
A login screen should mask passwords when displaying them back for confirmation.
Requirements:
•	Show only first and last characters.
•	Replace all middle characters with '*'.
•	Handle length < 3 safely (no crash).
Task: Input a password and print masked password. Example: Welcome123 -> W*******3.
**/

using System;
namespace PasswordMasking
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();

            //check if password is null or emoty
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password cannot be empty.");
                return;
            }

            //check password length
            if (password.Length < 3)
            {
                Console.WriteLine("Password length should be greater than 3");
                return;
            }
            
             // Initialize masked password
            string maskedPassword="";

            // First character
            maskedPassword+=password[0];
            // Middle characters replaced with *
            for(int i = 1; i < password.Length-1; i++)
            {
                maskedPassword +='*';
            }
             // Last character
            maskedPassword +=password[password.Length-1];
            Console.WriteLine($"Masked Password: {maskedPassword}");
        }
    }
}