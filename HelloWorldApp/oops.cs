using System;

namespace HelloWorldApp
{
    //parent of evry t in C# is System.Object


    // <summary>
        // Student Definition
    // </summary

    public class Student 
    {
        //#region Declaration

        public string Name;
        public string Department;
        public int RollNo;
        public string Course;
        // #endregion

        //#region Constructor
        public Student()
        {
            Console.WriteLine("Enter name, department, roll no, course of student:");
            Name = Console.ReadLine();
            Department = Console.ReadLine();
            RollNo = Convert.ToInt32(Console.ReadLine());
            Course = Console.ReadLine();
        }
        //#endregion

        // #region member functoions
        public void GetDetails()
        {
            Console.WriteLine("Student Data:");
            Console.WriteLine($"  Name: {Name}");
            Console.WriteLine($"  Department: {Department}");
            Console.WriteLine($"  RollNo: {RollNo}");
            Console.WriteLine($"  Course: {Course}");
        }
        //#endregion


    }

   public class Teacher
    {
        public int Id;
        public string Name;
        public string Department;

    }

    public class Attendance
    {
        public int ID;
        public string  Name;
        public string Date;
        public string Status;
    }

}
