using System;
namespace HotelRoomBookingSystem
{
    /// <summary>
    /// Represents a hotel room with booking and pricing details.
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Unique room number.
        /// </summary>
        public int RoomNumber { get; set; }

        /// <summary>
        /// Type of room (Single, Double, Suite).
        /// </summary>
        public string RoomType { get; set; }

        /// <summary>
        /// Price charged per night.
        /// </summary>
        public double PricePerNight { get; set; }

        /// <summary>
        /// Indicates whether the room is currently available.
        /// Default value is true.
        /// </summary>
        public bool IsAvailable { get; set; } = true;
    }
}
