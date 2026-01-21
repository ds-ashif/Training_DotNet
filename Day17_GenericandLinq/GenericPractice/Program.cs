using System;

namespace GenericPractice
{
    /// <summary>
    /// Entry point of the application.
    /// Demonstrates the usage of generics and delegates
    /// such as <see cref="Predicate{T}"/>.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method where program execution begins.
        /// This method showcases:
        /// 1. Generic class instantiation with different data types.
        /// 2. Usage of a Predicate delegate to test a condition.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments passed to the application.
        /// </param>
        static void Main(string[] args)
        {
            #region Generics Demonstration

            /// <summary>
            /// Demonstrates generic class usage with a value type (int).
            /// </summary>
            CreateGenerics<int> obj = new CreateGenerics<int>();
            Console.WriteLine(obj.GetType());

            /// <summary>
            /// Demonstrates generic class usage with a reference type (Student).
            /// </summary>
            CreateGenerics<Student> obj1 = new CreateGenerics<Student>();
            Console.WriteLine(obj1.GetType());

            #endregion

            #region Predicate Delegate Demonstration

            Console.WriteLine("\n====== one delegate Type: Predicate ======");
            Console.WriteLine("UseCase: for methods that test a condition. Always take one input and return bool.");

            /// <summary>
            /// Calls a Predicate-based method to determine
            /// whether a number is even.
            /// </summary>
            bool result = Predicates.IsEvenNumber(4);
            Console.WriteLine(result);

            #endregion
        }
    }
}
