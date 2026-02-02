using System;
using System.Collections.Generic;

namespace Students
{
    public class Program
    {
        /// <summary>
        /// The main entry point of the program.
        /// </summary>
        public static void Main()
        {
            // Sample list of students
            List<Student> students=new List<Student>
            {
                new Student(1,"Alice",85,90,78),
                new Student(2,"Bob",75,80,88),
                new Student(3,"Charlie",95,85,92),
                new Student(4,"Diana",65,70,60)

            };

            // Calculating and displaying average marks for each student and class average
            AverageCalculator<Student> calculator = new AverageCalculator<Student>();
            foreach(var student in students)
            {
                double average=calculator.CalculateAverage(student);
                Console.WriteLine($"Average marks of {student.Name} is {average:F2}");
            }
            Console.WriteLine($"Class Average: {calculator.CalculateClassAverage(students):F2}");

            Console.WriteLine("----------------------------------------------------------------------------------");

            // Calculating and displaying ranks based on average marks
            RankCalculator rankCalculator = new RankCalculator();
            rankCalculator.CalculateRanks(students,Remarks.PrintRemark);


        }
    }
}
