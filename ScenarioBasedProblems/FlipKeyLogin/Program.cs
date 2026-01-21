using System;
using System.Text;

namespace FlipKeyLogin
{
    /// <summary>
    /// The main program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Serves as the entry point for the application.
        /// </summary>
        /// <param name="args">An array of command-line arguments supplied to the application.</param>
        public static void Main(string[] args)
        {
            // Prompt the user to enter a password
            Console.WriteLine("Enter your Input: ");
            // Read the user input
            string word = Console.ReadLine();

            // Create an instance of Program to call the instance method
            Program program = new Program();
            // Call the CleanseAndInvert method and store the result
            string result = program.CleanseAndInvert(word);

            // Display the result or an error message based on the output
            if (result == "")
            {
                Console.WriteLine("Invalid input");
            }
            else
            {
                Console.WriteLine("The generated Key is: " + result);
            }
        }

        /// <summary>
        /// Cleanses and inverts the input string according to specific rules.
        /// </summary>
        /// <remarks>
        /// Processing rules:
        /// 1. Validates that input is not null and has at least 6 characters
        /// 2. Validates that input contains only letters (no spaces, digits, or special characters)
        /// 3. Converts input to lowercase
        /// 4. Removes all characters with even ASCII values
        /// 5. Reverses the remaining characters
        /// 6. Converts characters at even positions (0-based index) to uppercase
        /// </remarks>
        /// <param name="word">The input string to process.</param>
        /// <returns>The processed string, or an empty string if validation fails.</returns>
        public string CleanseAndInvert(string word)
        {
            // Input Validation for null or length less than 6
            if (string.IsNullOrEmpty(word) || word.Length < 6)
            {
                return "";
            }

            // Input Validation for digits, whitespace, or non-letter characters
            foreach (char c in word)
            {
                if (char.IsDigit(c) || char.IsWhiteSpace(c) || !char.IsLetter(c))
                {
                    return "";
                }
            }

            // Convert to lowercase
            word = word.ToLower();

            // Remove characters with even ASCII values
            StringBuilder sb = new StringBuilder();
            foreach (char c in word)
            {
                if ((int)c % 2 != 0)
                {
                    sb.Append(c);
                }
            }
            
            // Reverse the string and convert characters at even positions to uppercase
            char[] charArray = sb.ToString().ToCharArray();
            Array.Reverse(charArray);
            for (int i = 0; i < charArray.Length; i++)
            {
                if (i % 2 == 0)
                {
                    charArray[i] = char.ToUpper(charArray[i]);
                }
            }

            // Return the final processed string
            return new string(charArray);
        }
    }
}