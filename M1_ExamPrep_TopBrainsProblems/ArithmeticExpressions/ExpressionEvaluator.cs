using System;

namespace ArithmeticExpressions
{
    /// <summary>
    /// Provides functionality to evaluate simple arithmetic expressions
    /// containing two integers and one operator.
    /// </summary>
    public class ExpressionEvaluator
    {
        /// <summary>
        /// Evaluates an arithmetic expression provided as a string.
        /// </summary>
        /// <param name="input">
        /// A string expression in the format: 
        /// <c>number operator number</c> (e.g., "10 + 5").
        /// </param>
        /// <returns>
        /// A string containing either the calculated result or an error message.
        /// Possible error messages:
        /// <list type="bullet">
        /// <item><description>Error:InvalidExpression</description></item>
        /// <item><description>Error:InvalidNumber</description></item>
        /// <item><description>Error:UnknownOperator</description></item>
        /// <item><description>Error:DivideByZero</description></item>
        /// </list>
        /// </returns>
        public static string Evaluate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "Error:InvalidExpression";

            string[] parts = input.Split(" ");

            if (parts.Length != 3)
                return "Error:InvalidExpression";

            bool success1 = int.TryParse(parts[0], out int num1);
            bool success2 = int.TryParse(parts[2], out int num2);
            string operation = parts[1];

            if (!success1 || !success2)
                return "Error:InvalidNumber";

            if (!(operation == "+" || operation == "-" || operation == "*" || operation == "/"))
                return "Error:UnknownOperator";

            if (operation == "/" && num2 == 0)
                return "Error:DivideByZero";

            return operation switch
            {
                "+" => (num1 + num2).ToString(),
                "-" => (num1 - num2).ToString(),
                "*" => (num1 * num2).ToString(),
                "/" => (num1 / num2).ToString(),
                _ => "Error:UnknownOperator"
            };
        }
    }
}
