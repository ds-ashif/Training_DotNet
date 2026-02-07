using System;
using System.Collections.Concurrent;
using System.Threading;

// Represents a seat in the booking system
public class Seat
{
    public int SeatNo { get; }                 // Seat number
    public bool IsBooked { get; private set; } // Booking status
    public string? BookedBy { get; private set; } // User who booked

    // Lock object used to protect booking operation
    private readonly object _lock = new object();

    // Constructor initializes seat number
    public Seat(int seatNo)
    {
        SeatNo = seatNo;
    }

    // Thread-safe booking attempt
    public bool TryBook(string userId)
    {
        // Only one thread can enter this block at a time
        lock (_lock)
        {
            // If already booked, reject
            if (IsBooked)
                return false;

            // Book seat
            IsBooked = true;
            BookedBy = userId;

            return true;
        }
    }
}

// Service that manages seat booking
public class SeatBookingService
{
    // Thread-safe collection storing seats
    private readonly ConcurrentDictionary<int, Seat> _seats =
        new ConcurrentDictionary<int, Seat>();

    // Initialize seats
    public SeatBookingService(int totalSeats)
    {
        for (int i = 1; i <= totalSeats; i++)
        {
            _seats[i] = new Seat(i);
        }
    }

    // API used by clients to book a seat
    public bool BookSeat(int seatNo, string userId)
    {
        // Try to get seat
        if (!_seats.TryGetValue(seatNo, out var seat))
            return false; // seat not found

        // Attempt booking
        return seat.TryBook(userId);
    }
}

// Application entry point
class Program
{
    static void Main()
    {
        // Create booking service with 1 seat
        var service = new SeatBookingService(1);

        // Thread representing User A booking
        Thread t1 = new Thread(() =>
            Console.WriteLine("UserA booking: " +
                service.BookSeat(1, "UserA")));

        // Thread representing User B booking at same time
        Thread t2 = new Thread(() =>
            Console.WriteLine("UserB booking: " +
                service.BookSeat(1, "UserB")));

        // Start concurrent booking attempts
        t1.Start();
        t2.Start();

        // Wait for both threads to finish
        t1.Join();
        t2.Join();
    }
}
