/**
Q7. Ticket Booking - Static Counter + Object Count
A cinema generates ticket numbers automatically.
Requirements:
•	Create class Ticket with static LastTicketNo starting at 1000.
•	Each new ticket increments the counter and assigns a new number.
Task: Book N tickets and print each generated ticket number.
**/

using System;
namespace TicketBooking
{
     /// <summary>
    /// Entry point of ticket booking application.
    /// </summary>
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter number of tickets to book:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("\nGenerated Ticket Numbers:");

            // Create N ticket objects
            for(int i = 0; i <= n; i++)
            {
                Ticket ticket = new Ticket();
                Console.WriteLine($"Ticket {i + 1}: {ticket.TicketNo}");
            }
        }
    }
}