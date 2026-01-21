using System;

namespace CustomExceptions
{
    #region Program

    /// <summary>
    /// Demonstrates the usage of a custom exception
    /// with try-catch and exception wrapping.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point.
        /// Executes a division operation and handles errors
        /// using a custom exception.
        /// </summary>
        public static void Main()
        {
            try
            {
                // Attempt to divide numbers (will cause an exception)
                int result = Divide(10, 0);

                // This line will not execute if an exception occurs
                Console.WriteLine("The Result is: " + result);
            }
            catch (CustomException ex)
            {
                // Catch and display user-friendly error message
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        #region Helper Methods

        /// <summary>
        /// Divides two integers and throws a custom exception
        /// if an error occurs during the operation.
        /// </summary>
        /// <param name="a">Dividend</param>
        /// <param name="b">Divisor</param>
        /// <returns>Result of division</returns>
        private static int Divide(int a, int b)
        {
            try
            {
                // Perform division
                return a / b;
            }
            catch (Exception e)
            {
                // Wrap the original exception inside a custom exception
                // to provide controlled and secure error handling
                throw new CustomException("Division failed: " + e.Message, e);
            }
        }

        #endregion
    }

    #endregion
}
