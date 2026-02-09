/**
Q5. Notifications - Interface + Multiple Implementations
A system can send the same alert through multiple channels.
Requirements:
•	Create interface INotifier with method Send(string message).
•	Implement EmailNotifier, SmsNotifier, WhatsAppNotifier.
Task: Store notifiers in an array/list and send a single message to all.
**/

using System;

namespace Notifications
{
    class SMSNotifier : INotifier
    {
        public string Send(string message)
        {
            return $"SMS Notification Sent: {message}";
        }
    }
}