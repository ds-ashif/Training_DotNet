namespace InvigilatorsScheduling
{
    /// <summary>
    /// Defines availability-related behavior for invigilators.
    /// </summary>
    public interface IAvailability
    {
        /// <summary>
        /// Determines whether the invigilator is available
        /// for a given exam date and time.
        /// </summary>
        /// <param name="examDate">Date of the exam</param>
        /// <param name="examTime">Time of the exam</param>
        /// <returns>True if available; otherwise false.</returns>
        bool IsAvailable(string examDate, string examTime);
    }
}
