using System;

namespace MultipleInheritanceExample
{
    /// <summary>
    /// Entry point of the Multiple Inheritance Example application.
    /// </summary>
    /// <remarks>
    /// Demonstrates how C# supports multiple inheritance
    /// through interfaces instead of classes.
    /// </remarks>
    public class Program
    {
        /// <summary>
        /// Main method where program execution begins.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments passed at runtime.
        /// These are not used in the current implementation.
        /// </param>
        static void Main(string[] args)
        {
            /// <summary>
            /// Demonstrates interface-based reference
            /// using vegetarian behavior.
            /// </summary>
            IVegEater veg = new VegEater();
            veg.EatVeg();

            /// <summary>
            /// Demonstrates interface-based reference
            /// using non-vegetarian behavior.
            /// </summary>
            INonVegEater nonVeg = new NonVegEater();
            nonVeg.EatNonVeg();

            /// <summary>
            /// Demonstrates multiple interface implementation
            /// through the Visitor class.
            /// </summary>
            Visitor visitor = new Visitor();
            visitor.EatVeg();
            Console.WriteLine(visitor.nvtaste);
        }
    }
}
