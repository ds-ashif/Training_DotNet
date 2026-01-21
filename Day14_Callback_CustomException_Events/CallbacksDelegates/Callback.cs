using System;

namespace CallbacksDelegates
{
    #region Delegate Definition

    /// <summary>
    /// Delegate that represents a callback method
    /// used to notify order confirmation.
    /// </summary>
    /// <param name="message">Confirmation message</param>
    public delegate void Notify(string message);

    #endregion

    #region Callback Demonstration

    /// <summary>
    /// Demonstrates the use of callbacks and delegates in C#.
    /// </summary>
    public class Callback
    {
        /// <summary>
        /// Places an order and invokes a callback method
        /// once the order is confirmed.
        /// </summary>
        /// <param name="orderId">Unique order identifier</param>
        /// <param name="callback">Callback method to notify confirmation</param>
        public void PlaceOrder(string orderId, Notify callback)
        {
            // Display order details
            Console.WriteLine($"Your Order id is: {orderId}");

            // Invoke callback if it is not null
            callback?.Invoke($"{orderId} confirmation done");
        }

        #region Program Entry Point

        /// <summary>
        /// Application entry point.
        /// Demonstrates callbacks using email and SMS notifications.
        /// </summary>
        public static void Main()
        {
            // Create an instance of Callback
            var cb = new Callback();

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
