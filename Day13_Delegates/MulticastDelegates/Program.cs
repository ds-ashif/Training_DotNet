using System;

namespace MulticastDelegates
{
    #region Delegates

    /// <summary>
    /// Represents a delegate that can reference one or more methods
    /// which accept a string message and return no value.
    /// 
    /// This delegate is used to demonstrate multicast behavior,
    /// where multiple methods are invoked sequentially.
    /// </summary>
    /// <param name="message">
    /// Message passed to each subscribed method.
    /// </param>
    public delegate void MyDelegate(string message);

    #endregion

    /// <summary>
    /// Demonstrates multicast delegates by invoking
    /// multiple methods using a single delegate instance.
    /// </summary>
    public class Program
    {
        #region Delegate Target Methods

        /// <summary>
        /// Prints the message prefixed with identifier "A".
        /// </summary>
        /// <param name="message">Message to display</param>
        static void MethodA(string message) => Console.WriteLine("A: " + message);


        /// <summary>
        /// Prints the message prefixed with identifier "B".
        /// </summary>
        /// <param name="message">Message to display</param>
        static void MethodB(string message) => Console.WriteLine("B: " + message);


        /// <summary>
        /// Prints the message prefixed with identifier "C".
        /// </summary>
        /// <param name="message">Message to display</param>
        static void MethodC(string message)
            => Console.WriteLine("C: " + message);

        #endregion

        #region Application Entry Point

        /// <summary>
        /// Main entry point of the application.
        /// Demonstrates how multiple methods can be combined
        /// and executed using a multicast delegate.
        /// </summary>
        /// <param name="args">Command-line arguments</param>
        static void Main(string[] args)
        {
            // Create delegate instance and attach methods
            MyDelegate d = MethodA;
            d += MethodB;
            d += MethodC;

            /*
             * Invoking the delegate executes all attached methods
             * in the order they were added:
             * MethodA -> MethodB -> MethodC
             */
            d("Hello Delegates");

            // Prevent console window from closing immediately
            Console.ReadLine();
        }

        #endregion
    }
}
