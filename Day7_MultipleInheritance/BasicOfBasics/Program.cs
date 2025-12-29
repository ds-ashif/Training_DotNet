using System;

namespace BasicOfBasics
{
    /// <summary>
    /// Entry point of the BasicOfBasics application.
    /// Demonstrates method overloading, ref parameters,
    /// out parameters, and checked arithmetic operations.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method where application execution begins.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments passed at runtime.
        /// These are not used in the current implementation.
        /// </param>
        static void Main(string[] args)
        {
            SomeClass someClass = new SomeClass();

            // This block is intentionally disabled.
            // Remove the 'false' condition to execute this section.
            if (false)
            {
                /// <summary>
                /// Demonstrates calling a method with a single
                /// integer parameter and receiving a string result.
                /// </summary>
                string res = someClass.SomeMethod(5);
                Console.WriteLine(res);

                /// <summary>
                /// Demonstrates usage of ref parameters.
                /// Values must be initialized before passing as ref.
                /// </summary>
                int input1 = 3;
                int input2 = 7;

                int sum = someClass.SomeMethod(ref input1, ref input2);

                Console.WriteLine($"The method with two int parameters {input1},{input2} is calling {sum}");
                Console.WriteLine($"input1: {input1}");
                Console.WriteLine($"input2: {input2}");
            }

            // Demonstrates usage of out parameters
            int n = 10;
            int square, half, addBy3;

            int original = someClass.MultiMath(n, out square, out half, out addBy3);

            Console.WriteLine($"Original: {original}, Square: {square}, half: {half}, addBy3: {addBy3}");
        }
    }

    /// <summary>
    /// Contains methods that demonstrate basic C# concepts
    /// such as method overloading, ref and out parameters,
    /// and checked arithmetic operations.
    /// </summary>
    public class SomeClass
    {
        /// <summary>
        /// Demonstrates a simple method that accepts an integer
        /// and returns a formatted string.
        /// </summary>
        /// <param name="n">Integer input value.</param>
        /// <returns>A descriptive string containing the input value.</returns>
        public string SomeMethod(int n)
        {
            return $"This method with int parameter is calling:{n}";
        }

        /// <summary>
        /// Demonstrates usage of ref parameters.
        /// Modifies the original values passed to the method.
        /// </summary>
        /// <param name="input1">First integer passed by reference.</param>
        /// <param name="input2">Second integer passed by reference.</param>
        /// <returns>The sum of the original input values.</returns>
        public int SomeMethod(ref int input1, ref int input2)
        {
            int n = input1 + input2;
            input1 = 100;
            input2 = 300;
            return n;
        }

        /// <summary>
        /// Demonstrates usage of out parameters to return
        /// multiple calculated values from a single method.
        /// </summary>
        /// <param name="n">Input number.</param>
        /// <param name="sqrValue">Outputs the square of the number.</param>
        /// <param name="halfValue">Outputs half of the number.</param>
        /// <param name="addBy3">Outputs the number increased by 3.</param>
        /// <returns>The original input value.</returns>
        public int MultiMath(int n, out int sqrValue, out int halfValue, out int addBy3)
        {
            sqrValue = 0;
            sqrValue = n * n;
            halfValue = n / 2;
            addBy3 = n + 3;
            return n;
        }

        /// <summary>
        /// Demonstrates checked arithmetic to prevent
        /// integer overflow during addition.
        /// </summary>
        /// <param name="input1">First integer value.</param>
        /// <param name="input2">Second integer value.</param>
        /// <returns>The sum of the two integers.</returns>
        /// <exception cref="OverflowException">
        /// Thrown if the addition exceeds the limits of an integer.
        /// </exception>
        public int Add(int input1, int input2)
        {
            checked
            {
                int c = input1 + input2;
                return c;
            }
        }
    }
}
