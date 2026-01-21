using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    #region Application Entry Point

    /// <summary>
    /// Entry point of the application.
    /// This method initializes execution and invokes
    /// the LINQ demonstration method.
    /// </summary>
    static void Main(string[] args)
    {
        // Uncomment any method below to run a specific LINQ example
        // LinqExample();
        // LinqExample2();
        // LinqExample3();

        // Executes LINQ query to calculate student averages
        StudentDetails();
    }

    #endregion

    #region Student LINQ Example

    /// <summary>
    /// Demonstrates the use of LINQ query syntax to:
    /// 1. Project student data into an anonymous object
    /// 2. Calculate average marks for each student
    /// 3. Display the result in the console
    /// </summary>
    private static void StudentDetails()
    {
        #region Student Data Initialization

        // List of students with academic details
        List<Student> Students = new List<Student>
        {
            new Student{ RollNo = 1, Name = "Asad",  MathMarks = 85, HindiMarks = 95 },
            new Student{ RollNo = 2, Name = "Bob",   MathMarks = 75, HindiMarks = 65 },
            new Student{ RollNo = 3, Name = "Varav", MathMarks = 55, HindiMarks = 45 },
            new Student{ RollNo = 4, Name = "Abhi",  MathMarks = 95, HindiMarks = 85 }
        };

        #endregion

        #region LINQ Query - Anonymous Projection

        // LINQ query syntax is used here to create an anonymous object
        // containing RollNo, Name, and a calculated Average value.
        // Note: This query uses deferred execution and will run
        // when the result is enumerated in the foreach loop.
        var studentAverage =
            from Student in Students
            select new
            {
                Student.RollNo,
                Student.Name,
                Average = (Student.MathMarks + Student.HindiMarks) / 2
            };

        #endregion

        #region Output Display

        // Output header
        System.Console.WriteLine("Student Averages: ");

        // Enumeration triggers execution of the LINQ query
        foreach (var avg in studentAverage)
        {
            // Display student name, roll number, and average marks
            System.Console.WriteLine($"{avg.Name} ID: {avg.RollNo}: {avg.Average}");
        }

        #endregion
    }

    #endregion
}
