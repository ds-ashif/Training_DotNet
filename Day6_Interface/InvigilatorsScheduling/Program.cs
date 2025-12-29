using System;
using InvigilatorsScheduling;

namespace InvigilatorsScheduling
{
    /// <summary>
    /// Entry point of the Invigilators Scheduling application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method where execution begins.
        /// </summary>

        static void Main(string[] args)
        {
            // Create HOD
            Hod hod = new Hod
            {
                Id = 1,
                Name = "Dr. Makul",
                Designation = "Head of Department",
                Permissions = "Schedule Exams, Assign Invigilators",
                DepartmentName = "Computer Science"
            };

            // Create Mentor
            Mentor mentor = new Mentor
            {
                Id = 101,
                Name = "Mr. Navdeep",
                Designation = "Assistant Professor",
                Permissions = "Invigilation",
                Sections = "A, B",
                TimeTable = "Mon-Fri"
            };

            // Create Exam
            Exam exam = new Exam
            {
                Subject = "Data Structures",
                ExamDate = "20-11-2025",
                ExamTime = "10:00 AM",
                Duration = 3,
                Venue = "Hall A"
            };

            // Create Department
            Department department = new Department
            {
                DepartmentName = "Computer Science",
                DepartmentCode = "CSE",
                DepartmentHod = hod
            };

            // HOD schedules exam
            IExamScheduler scheduler = hod;
            scheduler.ScheduleExam(exam);

            // Mentor availability check
            IAvailability availability = mentor;
            if (availability.IsAvailable(exam.ExamDate, exam.ExamTime))
            {
                scheduler.AssignInvigilator(exam, mentor);
            }

            Console.WriteLine("Invigilator scheduling completed.");
            //Console.ReadLine();
        }
    }
}
