using System;

namespace delegates
{
    #region Delegates

    /// <summary>
    /// Represents a method that formats a message to be printed.
    /// This delegate allows the printing behavior to be selected
    /// dynamically at runtime.
    /// </summary>
    /// <param name="message">
    /// Input message or customer name provided by the caller.
    /// </param>
    /// <returns>
    /// A formatted string that will be printed to the console.
    /// </returns>
    public delegate string PrintMessage(string message);

    #endregion

    /// <summary>
    /// Represents a printing company that prints messages
    /// based on customer-selected behavior using delegates.
    /// </summary>
    public class PrintingCompany
    {
        #region Properties

        /// <summary>
        /// Gets or sets the delegate that defines how
        /// the message should be printed.
        /// </summary>
        /// <remarks>
        /// The assigned method must match the <see cref="PrintMessage"/>
        /// delegate signature.
        /// </remarks>
        public PrintMessage CustomerChoicePrintMessage { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Prints the message using the customer-selected
        /// print strategy.
        /// </summary>
        /// <param name="message">
        /// Message or customer name to be printed.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// Thrown when no print behavior has been assigned.
        /// </exception>
        public void Print(string message)
        {
            // Defensive check to ensure delegate is assigned
            if (CustomerChoicePrintMessage == null)
            {
                throw new InvalidOperationException(
                    "Print behavior is not set. Please assign a print method."
                );
            }

            // Invoke the delegate to format the message
            string messageToPrint = CustomerChoicePrintMessage(message);

            // Output the formatted message
            Console.WriteLine(messageToPrint);
        }

        #endregion
    }
}
