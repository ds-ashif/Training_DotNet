using System;

namespace ArithmeticExpressions
{
    /// <summary>
    /// The main program class responsible for user interaction.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point of the application.
        /// Reads user input, evaluates the expression,
        /// and displays the result.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Enter string expression:");
            string input = Console.ReadLine() ?? "";

            string result = ExpressionEvaluator.Evaluate(input);

            Console.WriteLine("Result: " + result);
        }
    }
}
