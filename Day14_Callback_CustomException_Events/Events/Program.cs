using System;

namespace Events
{
    #region Event Arguments

    /// <summary>
    /// Provides data for the ThresholdReached event.
    /// Contains the value that triggered the event and the time it occurred.
    /// </summary>
    public class ThresholdReachedEventArgs : EventArgs
    {
        /// <summary>
        /// The value that exceeded the threshold.
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// The time when the threshold was reached.
        /// </summary>
        public DateTime Timestamp { get; }

        /// <summary>
        /// Initializes a new instance of the ThresholdReachedEventArgs class.
        /// </summary>
        /// <param name="value">Value that exceeded the threshold</param>
        /// <param name="timestamp">Time when the event occurred</param>
        public ThresholdReachedEventArgs(int value, DateTime timestamp)
        {
            Value = value;
            Timestamp = timestamp;
        }
    }

    #endregion

    #region Publisher

    /// <summary>
    /// Monitors integer values and raises an event when a specified threshold is reached.
    /// </summary>
    public class ValueMonitor
    {
        /// <summary>
        /// Event raised when the submitted value meets or exceeds the threshold.
        /// </summary>
        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;

        /// <summary>
        /// The threshold value to monitor against.
        /// </summary>
        private readonly int _threshold;

        /// <summary>
        /// Initializes a new instance of the ValueMonitor class.
        /// </summary>
        /// <param name="threshold">Threshold value (default is 500)</param>
        public ValueMonitor(int threshold = 500)
        {
            _threshold = threshold;
        }

        /// <summary>
        /// Submits a value for evaluation against the threshold.
        /// </summary>
        /// <param name="value">Input value</param>
        public void Submit(int value)
        {
            if (value >= _threshold)
            {
                // Raise event when threshold condition is met
                OnThresholdReached(new ThresholdReachedEventArgs(value, DateTime.UtcNow));
            }
        }

        /// <summary>
        /// Raises the ThresholdReached event.
        /// Marked virtual to allow derived classes to override behavior.
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            ThresholdReached?.Invoke(this, e);
        }
    }

    #endregion

    #region Subscriber

    /// <summary>
    /// Subscribes to threshold events and outputs messages to the console.
    /// </summary>
    public class ConsoleNotifier
    {
        /// <summary>
        /// Handles the ThresholdReached event.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        public void OnThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine(
                $"Threshold reached with value {e.Value} at {e.Timestamp:O}"
            );
        }
    }

    #endregion

    #region Program

    /// <summary>
    /// Application entry point.
    /// Demonstrates publisher-subscriber event handling in C#.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method where execution begins.
        /// </summary>
        public static void Main()
        {
            // Create publisher and subscriber
            var monitor = new ValueMonitor(500);
            var notifier = new ConsoleNotifier();

            // Subscribe to the event
            monitor.ThresholdReached += notifier.OnThresholdReached;

            Console.WriteLine("Enter numbers (type 'exit' to quit):");

            while (true)
            {
                Console.Write("Number> ");
                var input = Console.ReadLine();

                if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
                    break;

                if (int.TryParse(input, out var num))
                {
                    monitor.Submit(num);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }

            // Unsubscribe when finished (good practice)
            monitor.ThresholdReached -= notifier.OnThresholdReached;
        }
    }

    #endregion
}
