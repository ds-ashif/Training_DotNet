using System;

namespace HotelRoomBookingSystem
{
    /// <summary>
    /// Console application entry point for hotel booking system.
    /// Provides menu-driven interaction.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to the Hotel Room Booking System!");

            HotelManager hotelManager = new HotelManager();
            int choice;

            #region Menu Loop

            do
            {
                Console.WriteLine("\n1. Add Rooms");
                Console.WriteLine("2. Get Rooms by Type");
                Console.WriteLine("3. Book Rooms for specific Nights");
                Console.WriteLine("4. Rooms in Budget");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Room Number: ");
                        int roomNumber = int.Parse(Console.ReadLine());

                        Console.Write("Enter Room Type (Single/Double/Suite): ");
                        string roomtype = Console.ReadLine();

                        Console.Write("Enter Price: ");
                        double roomPrice = double.Parse(Console.ReadLine());

                        hotelManager.AddRoom(roomNumber, roomtype, roomPrice);
                        Console.WriteLine("Room Added Successfully!");
                        break;

                    case 2:
                        var grouped = hotelManager.GroupRoomsByType();

                        foreach (var entry in grouped)
                        {
                            Console.WriteLine("\nType: " + entry.Key);

                            foreach (var room in entry.Value)
                            {
                                Console.WriteLine(
                                    $"Room {room.RoomNumber} - {room.PricePerNight}");
                            }
                        }
                        break;

                    case 3:
                        Console.Write("Enter Room Number: ");
                        int rn = int.Parse(Console.ReadLine());

                        Console.Write("Enter Nights: ");
                        int nights = int.Parse(Console.ReadLine());

                        if (hotelManager.BookRoom(rn, nights))
                            Console.WriteLine("Room booked successfully!");
                        else
                            Console.WriteLine("Room not available.");

                        break;

                    case 4:
                        Console.Write("Min Price: ");
                        double min = double.Parse(Console.ReadLine());

                        Console.Write("Max Price: ");
                        double max = double.Parse(Console.ReadLine());

                        var rooms =
                            hotelManager.GetAvailableRoomsByPriceRange(min, max);

                        if (rooms.Count == 0)
                        {
                            Console.WriteLine("No rooms found in this budget.");
                        }
                        else
                        {
                            foreach (var room in rooms)
                                Console.WriteLine($"Room {room.RoomNumber} - {room.PricePerNight}");
                        }
                        break;
                }

            } while (choice != 5);

            #endregion
        }
    }
}
