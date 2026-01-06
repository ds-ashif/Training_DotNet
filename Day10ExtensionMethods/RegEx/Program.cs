using System.Text.RegularExpressions;

namespace RegEx
{
    #region Program class
    /// <summary>
    /// Implementing regex and mathing the pattern
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // field to match with pattern
            string input = "Error: TIMEOUT while calling API";

            string pattern = @"timeout";

            //checking timespan and matching with pattern
            var rx = new Regex(
                pattern,
                RegexOptions.IgnoreCase,
                TimeSpan.FromMilliseconds(150)
            );

            //printing reultant message.

            Console.WriteLine(rx.IsMatch(input) ? "Found" : "Not Found");

        }
    }
    #endregion
}
