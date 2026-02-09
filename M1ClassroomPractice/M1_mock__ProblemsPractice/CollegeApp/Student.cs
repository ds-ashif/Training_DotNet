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
    /// <summary>
    /// Derived class Student inheriting from Person.
    /// Adds roll number and marks.
    /// </summary>
    class Student : Person
    {
        
        public int RollNo{get; set;}
        public int Marks{get;set;}
        
        // Passing Name and Age to base constructor
        public Student(string name, int age, int rollno, int marks) : base(name, age)
        {
            RollNo = rollno;
            Marks = marks;
        }

        /// <summary>
        /// Displays student result.
        /// </summary>
        
        public void DisplayResult()
        {
            string result = (Marks<35) ? "Fail" : "Pass";
            Console.WriteLine("\nStudent Details");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Roll No: {RollNo}");
            Console.WriteLine($"Marks: {Marks}");
            Console.WriteLine($"Result: {result}");
        }
    }
}