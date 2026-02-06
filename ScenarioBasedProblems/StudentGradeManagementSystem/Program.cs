using System;

namespace StudentGradeManagementSystem
{
    /// <summary>
    /// Entry point of the Student Grade Management application.
    /// Demonstrates how student data and grades are managed.
    /// </summary>
    class Program
    {
        static void Main()
        {
            // Create manager responsible for handling students and grades
            SchoolManager manager = new SchoolManager();

            #region Add Students

            // Add sample students with grade levels
            // Student IDs are auto-generated starting from 1
            manager.AddStudent("Alina", "10th");
            manager.AddStudent("Bobby", "10th");
            manager.AddStudent("Charu", "11th");

            #endregion

            #region Add Grades

            // Add subject grades for students
            // Format: AddGrade(StudentId, Subject, Grade)

            // Grades for Alice (ID = 1)
            manager.AddGrade(1, "Math", 90);
            manager.AddGrade(1, "Science", 85);

            // Grades for Bob (ID = 2)
            manager.AddGrade(2, "Math", 80);
            manager.AddGrade(2, "Science", 88);

            // Grades for Charlie (ID = 3)
            manager.AddGrade(3, "Math", 95);
            manager.AddGrade(3, "Science", 92);

            #endregion

            #region Display Top Performers

            // Display top N students based on average grades
            Console.WriteLine("Top Performers:");

            // Get top 2 students
            var topStudents = manager.GetTopPerformers(2);

            // Print student names
            foreach (var s in topStudents){
                Console.WriteLine(s.Name);
            }

            #endregion
        }
    }
}
