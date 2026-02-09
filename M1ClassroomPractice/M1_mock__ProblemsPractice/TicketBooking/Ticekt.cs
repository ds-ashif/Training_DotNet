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
    /// Represents a cinema ticket.
    /// Generates automatic ticket numbers using a static counter.
    /// </summary>
    class Ticket
    {
        /// <summary>
        /// Static field to store last issued ticket number.
        /// Shared across all objects.
        /// Starts from 1000.
        /// </summary>
        private static int LastTicketNo = 1000;

        /// <summary>
        /// Ticket number for each ticket object.
        /// </summary>

        public int TicketNo{get; private set;}

         /// <summary>
        /// Constructor increments ticket counter
        /// and assigns new ticket number.
        /// </summary>
        
        public Ticket()
        {
            LastTicketNo++;  // Increment counter
            TicketNo=LastTicketNo;  // Assign ticket number
        }


    }
}