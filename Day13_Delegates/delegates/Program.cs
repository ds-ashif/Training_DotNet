using System;

namespace delegates
{
    /// <summary>
    /// Entry point of the application.
    /// Demonstrates the use of delegates to dynamically
    /// choose different message-printing behaviors at runtime.
    /// </summary>
    internal class Program
    {
        #region Application Entry Point

        /// <summary>
        /// Main method – application execution starts here.
        /// </summary>
        /// <param name="args">Command-line arguments</param>
        static void Main(string[] args)
        {
            // Create an instance of PrintingCompany
            PrintingCompany printingCompany = new PrintingCompany();

            /*
             * Assign a method to the delegate.
             * The delegate can point to ANY method
             * that matches the signature: string Method(string)
             */
            printingCompany.CustomerChoicePrintMessage = new PrintMessage(Method1);


            Console.WriteLine();

            // Uncomment any one of the following lines
            // to change behavior at runtime without changing Print logic

            // printingCompany.CustomerChoicePrintMessage = new PrintMessage(HappyNewYear);
            // printingCompany.CustomerChoicePrintMessage = new PrintMessage(HappyDiwali);

            // Invoke the print operation
            printingCompany.Print("Asad");

            // Keep console window open
            Console.ReadLine();
        }

        #endregion

        #region Delegate Target Methods

        /// <summary>
        /// Default welcome message implementation.
        /// </summary>
        /// <param name="message">Customer name or message</param>
        /// <returns>Formatted welcome message</returns>
        private static string Method1(string message)
        {
           
            return "Welcome to Delegate World --------------- " + message;
        }

        /// <summary>
        /// Prints a New Year greeting.
        /// </summary>
        /// <param name="message">Customer name</param>
        /// <returns>Happy New Year message</returns>
        private static string HappyNewYear(string message)
        {
            
            return "Happy New Year " + message;
        }

        /// <summary>
        /// Prints a Diwali greeting.
        /// </summary>
        /// <param name="message">Customer name</param>
        /// <returns>Happy Diwali message</returns>
        private static string HappyDiwali(string message)
        {
          
            return "Happy Diwali " + message;
        }

        #endregion
    }
}
