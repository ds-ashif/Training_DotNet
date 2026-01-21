using System;

namespace CustomExceptions
{
    #region Custom Exceptions

    /*
      BASIC CUSTOM EXCEPTION (Simple Version)
      ------------------------------------------------------------
      This version demonstrates the most basic way to create a custom exception by overriding the Message property.
 
      public class CustomException : Exception
      {
          public override string Message => "Internal Application Exception Occurred";
      }
     */

    /// <summary>
    /// Represents an advanced custom exception used to hide
    /// internal system messages from end users while allowing
    /// internal logging for debugging purposes.
    /// </summary>
    public class CustomException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the CustomException class.
        /// </summary>
        /// <param name="systemMessage">
        /// The internal system message intended for logging.
        /// </param>
        /// <param name="inner">
        /// Optional inner exception that caused this exception.
        /// </param>
        public CustomException(string systemMessage, Exception inner = null)
            : base(systemMessage, inner)
        {
        }

        /// <summary>
        /// Overrides the Message property to return a user-friendly message.
        /// The original system message is logged internally.
        /// </summary>
        public override string Message => HandleBase(base.Message);

        /// <summary>
        /// Handles internal logging of the system message and
        /// returns a generic message suitable for end users.
        /// </summary>
        /// <param name="systemMessage">Original exception message</param>
        /// <returns>Safe message to display to the user</returns>
        private static string HandleBase(string systemMessage)
        {
            // Simulate logging the detailed message to a file or logging system
            Console.WriteLine("Log to File : " + systemMessage);

            // Return a generic message to avoid exposing internal details
            return "Internal Exception. Contact Admin.";
        }
    }

    #endregion
}
