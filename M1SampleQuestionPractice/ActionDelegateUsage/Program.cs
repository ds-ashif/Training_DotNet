using System;
using System.Collections.Generic;

namespace ActionDelegateUsage
{
    /// <summary>
    /// Program class that have demonstration of Action delegate usage.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Processes a task using the provided Action delegate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="action"></param>
        public void ProcessTask<T>(T item, Action<T> action)
        {
            Console.WriteLine("Starting task processing...");
            action(item);
            Console.WriteLine("Task processing completed.");
        }

        /// <summary>
        /// Main method - entry point of the program.
        /// </summary>
        
        static void Main(string[] args)
        {
            // Example usage of Action delegate
            var program = new Program();
            program.ProcessTask("Hello, world!", msg => Console.WriteLine($"Sending message: {msg}"));
            Console.WriteLine("---------------------------------------------------");
            program.ProcessTask(120.70, amount => Console.WriteLine($"Processing payment of amount: {amount}"));

        }
    }
}