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
    /// Base class representing a person.
    /// Stores common details.
    /// </summary>
    class Person
    {
        public string Name{get; set;}
        public int Age{get; set;}

        // Base constructor
        public Person(string name,int age)
        {
            Name=name;
            age = age;
        }


    }

}