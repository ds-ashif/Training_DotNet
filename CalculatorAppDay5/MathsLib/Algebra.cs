using System;

namespace MathsLib
{
    /// <summary>
    /// Provides basic algebraic and arithmetic operations.
    /// This class is designed to be reusable across multiple application layers
    /// such as Console, Web API, or Desktop applications.
    /// </summary>
    
    public class Algebra
    {
        #region Addition

        /// <summary>
        /// Adds two integers and returns the result.
        /// </summary>
        /// <param name="a">First integer value.</param>
        /// <param name="b">Second integer value.</param>
        /// <returns>
        /// An <see cref="int"/> representing the sum of <paramref name="a"/> and <paramref name="b"/>.
        /// </returns>
        

        public int Add(int a, int b)
        {
            return a + b;
        }

        #endregion

        #region Subtraction

        /// <summary>
        /// Subtracts the second integer from the first integer.
        /// </summary>
        /// <param name="a">Value from which <paramref name="b"/> will be subtracted.</param>
        /// <param name="b">Value to subtract.</param>
        /// <returns>
        /// An <see cref="int"/> representing the difference between <paramref name="a"/> and <paramref name="b"/>.
        /// </returns>
        public int Subtract(int a, int b)
        {
            return a - b;
        }

        #endregion

        #region Multiplication

        /// <summary>
        /// Multiplies two integers and returns the product.
        /// </summary>
        /// <param name="a">First integer value.</param>
        /// <param name="b">Second integer value.</param>
        /// <returns>
        /// An <see cref="int"/> representing the product of <paramref name="a"/> and <paramref name="b"/>.
        /// </returns>
        public int Multiply(int a, int b)
        {
            return a * b;
        }

        #endregion

        #region Division

        /// <summary>
        /// Divides the first integer by the second integer.
        /// </summary>
        /// <param name="a">Dividend.</param>
        /// <param name="b">Divisor.</param>
        /// <returns>
        /// A <see cref="double"/> representing the quotient of the division.
        /// </returns>
        /// <exception cref="DivideByZeroException">
        /// Thrown when <paramref name="b"/> is zero.
        /// </exception>
        public double Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Divisor cannot be zero.");
            }

            return (double)a / b;
        }

        #endregion

        #region Advanced Helpers

        /// <summary>
        /// Calculates the square of a given integer.
        /// </summary>
        /// <param name="value">The value to square.</param>
        /// <returns>
        /// An <see cref="int"/> representing the square of <paramref name="value"/>.
        /// </returns>
        public int Square(int value)
        {
            return value * value;
        }

        /// <summary>
        /// Determines whether the given integer is even.
        /// </summary>
        /// <param name="value">The value to evaluate.</param>
        /// <returns>
        /// <c>true</c> if the value is even; otherwise, <c>false</c>.
        /// </returns>
        public bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        #endregion
    }
}
