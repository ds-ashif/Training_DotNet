using System;

/**
Q5. Notifications - Interface + Multiple Implementations
A system can send the same alert through multiple channels.
Requirements:
•	Create interface INotifier with method Send(string message).
•	Implement EmailNotifier, SmsNotifier, WhatsAppNotifier.
Task: Store notifiers in an array/list and send a single message to all.
**/

namespace Notifications
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter different notifiers in list.");
            Console.WriteLine("Available: whatsapp / sms / email");
            Console.WriteLine("Type 'done' to finish adding.");

            List<INotifier> notifiers = new List<INotifier>();

            Console.WriteLine("Enter notifiers source: whatsapp/sms/email");

            while(true)
            {
                Console.WriteLine("Add notifier");
                string notifier = Console.ReadLine().ToLower();

                if(notifier=="done") break;

                switch (notifier)
                {
                    case "sms":
                        notifiers.Add(new SMSNotifier());
                        break;
                    case "email":
                        notifiers.Add(new EmailNotifier());
                        break;
                    case "whatsapp":
                        notifiers.Add(new WhatsappNotifier());
                        break;
                    default:
                        Console.WriteLine("Invalid notifier type.");
                        break;

                }
            }

            Console.WriteLine("Enter message to send");
            string message = Console.ReadLine();

            Console.WriteLine("\nSending notifications...\n");

            foreach(var n in notifiers)
            {
                Console.WriteLine(n.Send(message));
            }
        }
    }
}