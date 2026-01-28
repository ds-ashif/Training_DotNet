using System;

namespace TPasswordGenerator
{
    class Program
    {
        // Method to validate username
        public static bool IsValidUsername(string userName)
        {
            // Username must be exactly 8 characters
            if (userName.Length != 8)
                return false;

            // First 4 characters must be uppercase alphabets
            for (int i = 0; i < 4; i++)
            {
                if (!char.IsUpper(userName[i]))
                    return false;
            }

            // 5th character must be '@'
            if (userName[4] != '@')
                return false;

            // Last 3 characters must be digits
            string courseIdString = userName.Substring(5, 3);
            if (!int.TryParse(courseIdString, out int courseId))
                return false;

            // Course ID must be between 101 and 115
            if (courseId < 101 || courseId > 115)
                return false;

            return true;
        }

        // Method to generate password
        public static string GeneratePassword(string userName)
        {
            int asciiSum = 0;

            // Convert first 4 characters to lowercase and sum ASCII values
            for (int i = 0; i < 4; i++)
            {
                char lowerChar = char.ToLower(userName[i]);
                asciiSum += (int)lowerChar;
            }

            // Last 2 digits of course ID
            string lastTwoDigits = userName.Substring(6, 2);

            return "TECH_" + asciiSum + lastTwoDigits;
        }

        /// <summary>
        /// The entry point of the application.
        /// Reads user input, validates the username,
        /// generates the password if valid,
        /// and displays the result.
        /// </summary>

        public static void Main()
        {
            Console.WriteLine("Enter the username");
            string userName = Console.ReadLine();

            if (!IsValidUsername(userName))
            {
                Console.WriteLine($"{userName} is an invalid username");
                return;
            }

            string password = GeneratePassword(userName);
            Console.WriteLine("Password: " + password);
        }
    }
}
