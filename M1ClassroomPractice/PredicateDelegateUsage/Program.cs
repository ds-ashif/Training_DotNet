using System;
using System.Collections.Generic;

namespace PredicateDelegateUsage
{
    /// <summary>
    /// Main program class to demonstrate Predicate delegate usage.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method - entry point of the program.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // Example usage of Predicate delegate
            ProcessData processData=new ProcessData();
            
            // Filtering even numbers from a list
            List<int> numbers = new List<int> { 10, 25, 30, 45, 50, 65, 70 };

            var evenNumbers = processData.FilterData(numbers,numbers=>numbers%2==0);
            Console.WriteLine("Even Numbers: " + string.Join(", ", evenNumbers));

            Console.WriteLine("---------------------------------------------------");

            // Filtering students with total marks greater than or equal to 75
            List<Student> students = new List<Student>
            {
                new Student { Name = "Alice", totalMarks = 85 },
                new Student { Name = "Bob", totalMarks = 55 },
                new Student { Name = "Charlie", totalMarks = 95 },
                new Student { Name = "David", totalMarks = 45 }
            };
            // Using Predicate to filter students
            var topScoreres = processData.FilterData(students, student => student.totalMarks >= 75);
            Console.WriteLine("Top Scorers: ");

            // Displaying the filtered students
            foreach(var student in topScoreres)
            {
                Console.WriteLine($"Name: {student.Name}, Total Marks: {student.totalMarks}");
            }
            
        }
    }
}