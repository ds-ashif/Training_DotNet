namespace InvigilatorsScheduling
{
    /// <summary>
    /// Represents an examination conducted by the university.
    /// </summary>
    public class Exam
    {
        /// <summary>
        /// Gets or sets the subject name.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the examination date.
        /// </summary>
        public string ExamDate { get; set; }

        /// <summary>
        /// Gets or sets the examination time.
        /// </summary>
        public string ExamTime { get; set; }

        /// <summary>
        /// Gets or sets the exam duration in hours.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets the exam venue.
        /// </summary>
        public string Venue { get; set; }
    }
}
