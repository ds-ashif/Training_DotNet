using System;
using System.Collections.Generic;

namespace Day10ExtensionMethods
{
    #region Program Class

    /// <summary>
    /// Demonstrates memory allocation behavior and garbage collection
    /// by allocating multiple byte arrays and measuring total memory usage.
    /// </summary>
    public class Program
    {
        #region Main Method

        /// <summary>
        /// Application entry point.
        /// Allocates memory objects and displays the total managed memory.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            var list = new List<byte[]>();

            for (int i = 0; i < 20000; i++)
            {
                list.Add(new byte[1024]);   //allocating memory
            }

            Console.WriteLine("Memory allocated.");
            Console.WriteLine("Total Memory:" + GC.GetTotalMemory(forceFullCollection: false));
        }

        #endregion
    }

    #endregion
}
