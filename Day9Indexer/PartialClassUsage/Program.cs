using System;

namespace PartialClassUsage
{
    /// <summary>
    /// Provides the entry point for the application.
    /// Purpose: To demonstrate indexers with partial classes.
    /// Learning Outcome: Understand how indexers work with partial class definitions.
    /// </summary>

    public class Program
    {
        static void Main(string[] args)
        {
            // Create a new Student instance
            Student student = new Student();
            student.RollNo = 107;
            student.Name = "Sahil";
            student.Address = "Hyderabad, India";

            // Add books using indexer
            student[0] = "Data Structures";
            student[1] = "Algorithms";
            student[2] = "Operating Systems";

            // Display student information
            Console.WriteLine("Student's Roll No: " + student.RollNo);
            Console.WriteLine("Student Name: " + student.Name);
            Console.WriteLine("Student Address: " + student.Address);
            Console.WriteLine("Book 1: " + student[0]);
            Console.WriteLine("Book 2: " + student[1]);
            Console.WriteLine("Book 3: " + student[2]);

            Console.WriteLine(); // Empty line

            // Call methods from both partial class files
            student.PrintMainClass();
            student.PrintPartial();
        }
    }
}
