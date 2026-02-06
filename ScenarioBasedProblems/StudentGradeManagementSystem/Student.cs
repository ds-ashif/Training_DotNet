using System.Collections.Generic;

namespace StudentGradeManagementSystem
{
    /// <summary>
    /// Represents a student and their academic record.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Unique student ID.
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Student full name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Grade level (9th, 10th, etc.).
        /// </summary>
        public string GradeLevel { get; set; }

        /// <summary>
        /// Dictionary storing subject and grade.
        /// Example: { "Math": 85, "Science": 90 }
        /// </summary>
        public Dictionary<string, double> Subjects { get; set; } = new Dictionary<string, double>();
    }
}
