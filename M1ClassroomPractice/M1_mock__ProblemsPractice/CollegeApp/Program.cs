/**
Q6. Student Result - Inheritance + Base Constructor
A college app stores people details and extends for students.
Requirements:
•	Create base class Person with Name and Age.
•	Create derived class Student with RollNo and Marks.
•	Pass Name and Age to base constructor using base(...).
Task: If Marks < 35 print 'Fail' else print 'Pass' along with student details.

**/

using System;

namespace CollegeApp
{
    class Program
    {
        /// <summary>
        /// Entry point of the program
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Enter student name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter age:");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter roll number:");
            int roll = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter marks:");
            int marks = int.Parse(Console.ReadLine());

            // Create student object
            Student student = new Student(name, age, roll, marks);

            // Display result
            student.DisplayResult();
        }
    }
}