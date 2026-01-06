namespace Day10ExtensionMethods
{
    #region Program Class
    public class Program
    {
        /// <summary>
        /// Entry point of the application.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            /// <summary>
            /// implements Palindrome checker using Extension Method
            /// </summary>
            Console.WriteLine("Enter a string to check if it's a palindrome:");
            ///<summary>Field to take input</summary>
            string? word= Console.ReadLine();

            /// <summary> field to store the result of palndrome function</summary>
            bool result =word.IsPalindrome();

            /// <summary> display the result</summary>
            if (result)
            {
                Console.WriteLine($"{word} is a palindrome.");
            }
            else
            {
                Console.WriteLine($"{word} is not a palindrome.");
            }
        }
    }
    #endregion
}
