using System;
using System.Collections.Generic;
using System.Text;

namespace StaticClassesAndMemebers
{
    /// <summary>
    /// Provides static members for managing and retrieving a roll number value.
    /// This class demonstrates static class functionality with utility methods.
    /// </summary>
    /// <remarks>
    /// This class cannot be instantiated. All members are static and shared 
    /// across the application domain.
    /// </remarks>
    public static class StaticLearning
    {
        public static int RollNo; // Static variable - shared across all access points

        /// <summary>
        /// Static constructor - called automatically once before first use.
        /// </summary>
        static StaticLearning()
        {
            RollNo = 2;
            Console.WriteLine("Static constructor called - initializing RollNo");
        }

        /// <summary>
        /// Static method to retrieve the current RollNo value.
        /// </summary>
        /// <returns>The current RollNo value</returns>
        public static int GetRollNo()
        {
            return RollNo;
        }

        /// <summary>
        /// Static method to count the number of characters in a string.
        /// </summary>
        /// <param name="sentence">The string to count characters from</param>
        /// <returns>The number of characters in the string</returns>
        public static int WordCount(this string sentence)
        {
            return sentence.Length;
        }
    }
}
