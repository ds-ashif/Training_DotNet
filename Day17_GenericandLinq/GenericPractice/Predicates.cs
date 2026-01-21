using System;

namespace GenericPractice
{
    /// <summary>
    /// Demonstrates the use of built-in delegates such as
    /// <see cref="Predicate{T}"/> and <see cref="Action{T}"/>.
    /// This class contains utility methods for condition checks,
    /// logging, and dynamic greeting actions.
    /// </summary>
    internal class Predicates
    {
        #region Predicate<T>

        /// <summary>
        /// Determines whether the given integer value is an even number.
        /// </summary>
        /// <param name="value">
        /// The integer value to be evaluated.
        /// </param>
        /// <returns>
        /// <c>true</c> if the value is even; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEvenNumber(int value)
        {
            Predicate<int> isEven = number => number % 2 == 0;
            return isEven(value);
        }

        #endregion

        #region Action<T> - Logger

        /// <summary>
        /// Logs a message to the console with a timestamp.
        /// Demonstrates the use of <see cref="Action{T}"/> for
        /// operations that do not return a value.
        /// </summary>
        /// <param name="message">
        /// The message to be logged.
        /// </param>
        public static void Log(string message)
        {
            Action<string> logger = msg =>
            {
                Console.WriteLine($"[LOG]: {msg} at {DateTime.Now}");
            };

            logger(message);
        }

        #endregion

        #region Greeting Actions

        /// <summary>
        /// Returns a greeting action based on the current system time.
        /// If the time is before noon, a morning greeting is returned;
        /// otherwise, a daytime greeting is returned.
        /// </summary>
        /// <returns>
        /// An <see cref="Action{String}"/> that writes an appropriate
        /// greeting message to the console.
        /// </returns>
        public static Action<string> GetGreeting()
        {
            if (DateTime.Now.Hour < 12)
                return GoodMorning();
            else
                return GoodDay();
        }

        /// <summary>
        /// Creates an action that prints a morning greeting message.
        /// </summary>
        /// <returns>
        /// An <see cref="Action{String}"/> that outputs a morning greeting.
        /// </returns>
        private static Action<string> GoodMorning()
        {
            return msg => Console.WriteLine("Hey, good morning ☀️");
        }

        /// <summary>
        /// Creates an action that prints a daytime greeting message.
        /// </summary>
        /// <returns>
        /// An <see cref="Action{String}"/> that outputs a daytime greeting.
        /// </returns>
        private static Action<string> GoodDay()
        {
            return msg => Console.WriteLine("Have a good day 😊");
        }

        #endregion
    }
}
