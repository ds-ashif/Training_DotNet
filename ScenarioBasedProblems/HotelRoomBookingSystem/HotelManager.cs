using System;
using System.Collections.Generic;

namespace HotelRoomBookingSystem
{
    /// <summary>
    /// Manages hotel room operations including
    /// adding rooms, booking, grouping, and filtering.
    /// </summary>
    public class HotelManager
    {
        #region Fields

        /// <summary>
        /// Stores all rooms in the hotel.
        /// </summary>
        public List<Room> rooms = new List<Room>();

        #endregion

        #region Room Management

        /// <summary>
        /// Adds a new room if it does not already exist.
        /// </summary>
        /// <param name="roomNumber">Unique room number</param>
        /// <param name="type">Room type</param>
        /// <param name="price">Price per night</param>
        public void AddRoom(int roomNumber, string type, double price)
        {
            // Check if room already exists
            foreach (var room in rooms)
            {
                if (room.RoomNumber == roomNumber)
                {
                    Console.WriteLine("Room already exists.");
                    return;
                }
            }

            // Add room after validation
            rooms.Add(new Room { RoomNumber = roomNumber, RoomType = type, PricePerNight = price, IsAvailable = true });
        }

        #endregion

        #region Grouping Operations

        /// <summary>
        /// Groups available rooms by room type.
        /// </summary>
        /// <returns>
        /// Dictionary where key is room type
        /// and value is list of available rooms.
        /// </returns>
        public Dictionary<string, List<Room>> GroupRoomsByType()
        {
            Dictionary<string, List<Room>> roomsByType =
                new Dictionary<string, List<Room>>();

            foreach (var room in rooms)
            {
                // Skip booked rooms
                if (!room.IsAvailable) continue;

                if (!roomsByType.ContainsKey(room.RoomType))
                    roomsByType[room.RoomType] = new List<Room>();

                roomsByType[room.RoomType].Add(room);
            }

            return roomsByType;
        }

        #endregion

        #region Booking Operations

        /// <summary>
        /// Books a room if available and calculates total cost.
        /// </summary>
        /// <param name="roomNumber">Room number to book</param>
        /// <param name="nights">Number of nights</param>
        /// <returns>True if booking successful, otherwise false</returns>
        public bool BookRoom(int roomNumber, int nights)
        {
            foreach (var room in rooms)
            {
                if (room.RoomNumber == roomNumber && room.IsAvailable)
                {
                    double totalPrice = room.PricePerNight * nights;

                    Console.WriteLine($"Total Cost: {totalPrice}");

                    room.IsAvailable = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Filtering Operations

        /// <summary>
        /// Retrieves available rooms within a price range.
        /// </summary>
        /// <param name="min">Minimum price</param>
        /// <param name="max">Maximum price</param>
        /// <returns>List of rooms within budget</returns>
        public List<Room> GetAvailableRoomsByPriceRange(double min, double max)
        {
            List<Room> roomsInBudget = new List<Room>();

            foreach (var room in rooms)
            {
                if (room.IsAvailable &&
                    room.PricePerNight >= min &&
                    room.PricePerNight <= max)
                {
                    roomsInBudget.Add(room);
                }
            }

            return roomsInBudget;
        }

        #endregion
    }
}
