namespace InvigilatorsScheduling
{
    /// <summary>
    /// Represents a mentor who can act as an invigilator.
    /// </summary>
    public class Mentor : Role, IAvailability
    {
        /// <summary>
        /// Gets or sets the sections handled by the mentor.
        /// </summary>
        public string Sections { get; set; }

        /// <summary>
        /// Gets or sets the mentor timetable.
        /// </summary>
        public string TimeTable { get; set; }

        /// <inheritdoc/>
        public override string GetRole()
        {
            return "Mentor";
        }

        /// <inheritdoc/>
        public bool IsAvailable(string examDate, string examTime)
        {
            Console.WriteLine($"Checking availability for {Name} on {examDate} at {examTime}");
            return true;
        }
    }
}
