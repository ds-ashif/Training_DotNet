using System;

namespace CallbacksDelegates
{
    #region Delegate Information

    /*
     * NOTE:
     * In this example, the built-in Action<string> delegate is used
     * instead of creating a custom delegate.
     * 
     * Action<string> represents a method that:
     * - Takes a string parameter
     * - Returns void
     */

    #endregion

    #region Callback Demonstration

    /// <summary>
    /// Demonstrates the use of callbacks using the built-in Action delegate.
    /// </summary>
    public class CallbackwithAction
    {
        /// <summary>
        /// Places an order and invokes the provided callback
        /// once the order is confirmed.
        /// </summary>
        /// <param name="orderId">Unique order identifier</param>
        /// <param name="callback">
        /// Callback method executed after order confirmation.
        /// Uses Action&lt;string&gt; instead of a custom delegate.
        /// </param>
        public void PlaceOrder(string orderId, Action<string> callback)
        {
            // Display order information
            Console.WriteLine($"Your Order id is: {orderId}");

            // Invoke the callback if it is not null
            callback?.Invoke($"{orderId} confirmation done");
        }

        #region Program Entry Point

        /// <summary>
        /// Application entry point.
        /// Demonstrates callbacks using Action delegates
        /// for different notification mechanisms.
        /// </summary>
        public static void Main()
        {
            // Create an instance of the callback handler
            var cb = new CallbackwithAction();

            // Pass different callback methods
            cb.PlaceOrder("ORD-123", SendEmail);
            cb.PlaceOrder("ORD-124", SendSMS);
        }

        #endregion

        #region Callback Methods

        /// <summary>
        /// Simulates sending an email notification.
        /// </summary>
        /// <param name="message">Notification message</param>
        public static void SendEmail(string message)
        {
            Console.WriteLine($"Email: {message}");
        }

        /// <summary>
        /// Simulates sending an SMS notification.
        /// </summary>
        /// <param name="message">Notification message</param>
        public static void SendSMS(string message)
        {
            Console.WriteLine($"SMS: {message}");
        }

        #endregion
    }

    #endregion
}
