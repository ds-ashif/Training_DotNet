namespace InvigilatorsScheduling
{
    /// <summary>
    /// Represents the Head of Department (HOD).
    /// </summary>
    /// <remarks>
    /// The HOD is responsible for scheduling exams
    /// and assigning invigilators.
    /// </remarks>
    public class Hod : Role, IExamScheduler
    {
        /// <summary>
        /// Gets or sets the department name.
        /// </summary>
        public string DepartmentName { get; set; }

        /// <inheritdoc/>
        public override string GetRole()
        {
            return "HOD";
        }

        /// <inheritdoc/>
        public void ScheduleExam(Exam exam)
        {
            Console.WriteLine("----- Exam Scheduled by HOD -----");
            Console.WriteLine($"Department   : {DepartmentName}");
            Console.WriteLine($"Subject      : {exam.Subject}");
            Console.WriteLine($"Date         : {exam.ExamDate}");
            Console.WriteLine($"Time         : {exam.ExamTime}");
            Console.WriteLine($"Duration     : {exam.Duration} Hours");
            Console.WriteLine($"Venue        : {exam.Venue}");
            Console.WriteLine("--------------------------------\n");
        }

        /// <inheritdoc/>
        public void AssignInvigilator(Exam exam, Mentor mentor)
        {
            Console.WriteLine("----- Invigilator Assigned -----");
            Console.WriteLine($"Exam Subject : {exam.Subject}");
            Console.WriteLine($"Mentor Name  : {mentor.Name}");
            Console.WriteLine($"Sections     : {mentor.Sections}");
            Console.WriteLine("--------------------------------\n");
        }
    }
}
