using System;

namespace SwappingNumbers
{
    /// <summary>
    /// Demonstrates swapping of two numbers without using
    /// a temporary variable using ref and out keywords.
    /// </summary>
    public class SwapNumbers
    {
        #region Swap Using ref

        /// <summary>
        /// Swaps two numbers using the ref keyword.
        /// </summary>
        /// <param name="a">First number (by reference)</param>
        /// <param name="b">Second number (by reference)</param>
        public static void SwapUsingRef(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }

        #endregion

        #region Swap Using out

        /// <summary>
        /// Swaps two numbers using the out keyword.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="newA">Swapped value of a</param>
        /// <param name="newB">Swapped value of b</param>
        public static void SwapUsingOut(int a, int b, out int newA, out int newB)
        {
            newA = a + b;
            newB = newA - b;
            newA = newA - newB;
        }

        #endregion

        #region Program Entry Point

        /// <summary>
        /// Program entry point to demonstrate swapping methods.
        /// </summary>
        public static void Main()
        {
            int x = 1, y = 2;

            Console.WriteLine($"Before Swap (ref): x = {x}, y = {y}");
            SwapUsingRef(ref x, ref y);
            Console.WriteLine($"After Swap (ref):  x = {x}, y = {y}");

            int a = 3, b = 4;

            Console.WriteLine($"\nBefore Swap (out): a = {a}, b = {b}");
            SwapUsingOut(a, b, out int newA, out int newB);
            Console.WriteLine($"After Swap (out):  a = {newA}, b = {newB}");
        }

        #endregion
    }
}
