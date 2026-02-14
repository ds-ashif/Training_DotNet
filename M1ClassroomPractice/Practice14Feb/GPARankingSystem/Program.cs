using System;
using System.Collections.Generic;

namespace GPARankingSystem
{
    //student class having properties id, name, gpa of student
    class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }
    }

    //-----------------------Exceptions--------------
    class InvalidGPAException : Exception { }
    class DuplicateStudentException : Exception { }
    class StudentNotFoundException : Exception { }

    //-----------GPA Utility : it will handle all operations ------------

    class GPAUtility
    {
        //sorted in descending order as per gpa
        private static SortedDictionary<double, List<Student>> studentRecords = new SortedDictionary<double, List<Student>>(Comparer<double>.Create((a, b) => (b.CompareTo(a))));

        public void AddStudents(Student student)
        {
            if (student.GPA < 0 || student.GPA > 10)
                throw new InvalidGPAException();

            // duplicate check
            foreach (var list in studentRecords.Values)
            {
                foreach (var stud in list)
                {
                    if (stud.Id == student.Id) throw new DuplicateStudentException();
                }
            }

            if (!studentRecords.ContainsKey(student.GPA))
            {
                studentRecords[student.GPA] = new List<Student>();
            }
            studentRecords[student.GPA].Add(student);
        }

        // ---------- DISPLAY ----------
        public SortedDictionary<double, List<Student>> GetAllStudentsRank()
        {
            return studentRecords;
        }

        // ---------- UPDATE GPA ----------

        public void UpdateGPA(string id, double newGPA)
        {
            if (newGPA < 0 || newGPA > 10)
                throw new InvalidGPAException();

            foreach (var pair in studentRecords)
            {
                var list = pair.Value;

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Id == id)
                    {
                        Student stud = list[i];
                        list.RemoveAt(i);

                        if (list.Count == 0)
                            studentRecords.Remove(pair.Key);

                        stud.GPA = newGPA;
                        AddStudents(stud);

                        return;
                    }
                }
            }

            throw new StudentNotFoundException();
        }


    }

    class Program
    {
        static void Main()
        {
            GPAUtility utility = new GPAUtility();

            while (true)
            {
                Console.WriteLine("\n1 Display Ranking");
                Console.WriteLine("2 Update GPA");
                Console.WriteLine("3 Add Student");
                Console.WriteLine("4 Exit");

                int choice = int.Parse(Console.ReadLine());

                // ---------- DISPLAY ----------
                if (choice == 1)
                {
                    var data = utility.GetAllStudentsRank();

                    if (data.Count == 0)
                    {
                        Console.WriteLine("No students available.");
                        continue;
                    }

                    foreach (var gpaGroup in data)
                    {
                        foreach (var student in gpaGroup.Value)
                        {
                            Console.WriteLine(
                                $"Details: {student.Id} {student.Name} {student.GPA}");
                        }
                    }
                }

                // ---------- UPDATE GPA ----------
                else if (choice == 2)
                {
                    Console.WriteLine("Enter id and new GPA (<id> <gpa>):");

                    string[] input = Console.ReadLine().Split();

                    utility.UpdateGPA(
                        input[0],
                        double.Parse(input[1])
                    );

                    Console.WriteLine("GPA updated successfully.");
                }

                // ---------- ADD STUDENT ----------
                else if (choice == 3)
                {
                    Console.WriteLine("Enter student data (<id> <name> <gpa>):");

                    string[] input = Console.ReadLine().Split();

                    Student s = new Student
                    {
                        Id = input[0],
                        Name = input[1],
                        GPA = double.Parse(input[2])
                    };

                    utility.AddStudents(s);
                }

                // ---------- EXIT ----------
                else if (choice == 4)
                {
                    break;
                }
            }
        }
    }


}