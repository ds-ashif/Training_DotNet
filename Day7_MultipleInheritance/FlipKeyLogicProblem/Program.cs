using System;

namespace FlipKeyLogicProblem
{
    /// <summary>
    /// Contains logic to generate a flip key from a given input string.
    /// </summary>
    public class Program
    {
        #region CleanseAndInvert Method

        /// <summary>
        /// Cleanses the input string and generates a transformed key.
        /// </summary>
        /// <param name="input">
        /// Input string provided by the user.
        /// Must be at least 6 characters long and contain only letters.
        /// </param>
        /// <returns>
        /// A generated key string if input is valid;
        /// otherwise, an empty string.
        /// </returns>
        public static string CleanseAndInvert(string input)
        {
            string str1 = string.Empty;

            // Validate input length and null check
            if (input == null || input.Length < 6)
            {
                return str1;
            }

            // Iterate through each character of input
            
            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];

                // Reject digits, whitespace, and special characters
                if (!char.IsLetter(ch))
                {
                    return str1;
                }

                // Convert character to lowercase
                ch = char.ToLower(ch);

                // Get ASCII value of character
                int chAscii = (int)ch;

                // Append character if ASCII value is odd
                if (chAscii % 2 != 0)
                {
                    str1 += ch;
                }
            }

            // Reverse the filtered string
            char[] charArray = str1.ToCharArray();
            Array.Reverse(charArray);

            string reversedStr = new string(charArray);
            string ans = string.Empty;

            // Convert characters at even index to uppercase
            for (int i = 0; i < reversedStr.Length; i++)
            {
                char ch = reversedStr[i];

                if (i % 2 == 0)
                {
                    ans += char.ToUpper(ch);
                }
                else
                {
                    ans += ch;
                }
            }

            return ans;
        }

        #endregion

        #region Main Method

        /// <summary>
        /// Application entry point.
        /// Reads user input and displays the generated key.
        /// </summary>
        /// <param name="args">Command-line arguments</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the word");
            string word = Console.ReadLine();

            string ans = CleanseAndInvert(word);

            if (ans == string.Empty)
            {
                Console.WriteLine("Invalid Input");
            }
            else
            {
                Console.WriteLine($"The Generated key is - {ans}");
            }
        }

        #endregion

        
    }
}
