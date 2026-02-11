// Problem: Design a type-safe course registration system with constraints on student enrollment.

// 4. TEST SCENARIO: Create a simulation
// a) Create 3 EngineeringStudent instances
// b) Create 2 LabCourse instances with prerequisites
// c) Demonstrate:
//    - Successful enrollment
//    - Failed enrollment (capacity, prerequisite)
//    - Grade assignment
//    - GPA calculation
//    - Top student per course


using System;
using System.Collections.Generic;

namespace UnversityCourseRegisterationSystem
{
    public interface IStudent
    {
        int StudentId { get; }
        string Name { get; }
        int Semester { get; }
    }
    public interface ICourse
    {
        string CourseCode { get; }
        string Title { get; }
        int MaxCapacity { get; }
        int Credits { get; }
    }

    // 1. Generic enrollment system
    public class EnrollmentSystem<TStudent, TCourse>
        where TStudent : IStudent
        where TCourse : ICourse
    {
        private Dictionary<TCourse, List<TStudent>> _enrollments = new();

        // TODO: Enroll student with constraints
        public bool EnrollStudent(TStudent student, TCourse course)
        {
            // Rules:
            // - Course not at capacity
            // - Student not already enrolled
            // - Student semester >= course prerequisite (if any)
            // - Return success/failure with reason

            if (!_enrollments.ContainsKey(course))
            {
                _enrollments[course] = new List<TStudent>();
            }
            var students = _enrollments[course];

            // capacity check
            if (students.Count >= course.MaxCapacity)
            {
                Console.WriteLine("Enrollment failed: Course is full.");
                return false;
            }

            // already enrolled check
            foreach (var stud in students)
            {
                if (stud.StudentId == student.StudentId)
                {
                    Console.WriteLine("Enrollment Failed: Already enrolled.");
                    return false;
                }
            }

            // prerequisite check (only if course supports it)
            if (course is LabCourse lab)
            {
                if (student.Semester < lab.RequiredSemester)
                {
                    Console.WriteLine("Enrollment failed: Semester prerequisite not met.");
                    return false;
                }
            }

            students.Add(student);
            Console.WriteLine("Enrollment successful.");
            return true;


        }

        // TODO: Get students for course
        public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
        {
            // Return immutable list
            if (!_enrollments.ContainsKey(course))
            {
                return new List<TStudent>().AsReadOnly();
            }
            return _enrollments[course].AsReadOnly();
        }

        // TODO: Get courses for student
        public IEnumerable<TCourse> GetStudentCourses(TStudent student)
        {
            // Return courses student is enrolled in
            List<TCourse> result = new();
            foreach (var pair in _enrollments)
            {
                foreach (var person in pair.Value)
                {
                    if (person.StudentId == student.StudentId)
                    {
                        result.Add(pair.Key);
                        break;
                    }
                }
            }
            return result;
        }

        // TODO: Calculate student workload
        public int CalculateStudentWorkload(TStudent student)
        {
            // Sum credits of all enrolled courses
            int TotalCredits = 0;
            foreach (var pair in _enrollments)
            {
                foreach (var person in pair.Value)
                {
                    if (person.StudentId == student.StudentId)
                    {
                        TotalCredits += pair.Key.Credits;
                        break;
                    }
                }
            }

            return TotalCredits;

        }
    }

    // 2. Specialized implementations
    public class EngineeringStudent : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Semester { get; set; }
        public string Specialization { get; set; }
    }

    public class LabCourse : ICourse
    {
        public string CourseCode { get; set; }
        public string Title { get; set; }
        public int MaxCapacity { get; set; }
        public int Credits { get; set; }
        public string LabEquipment { get; set; }
        public int RequiredSemester { get; set; } // Prerequisite
    }

    // 3. Generic gradebook
    public class GradeBook<TStudent, TCourse>
    {
        private Dictionary<(TStudent, TCourse), double> _grades = new();

        // TODO: Add grade with validation
        public void AddGrade(TStudent student, TCourse course, double grade)
        {
            // Grade must be between 0 and 100
            // Student must be enrolled in course

            if (grade < 0 || grade > 100)
            {
                throw new ArgumentException("Grade must be bwetween 0 and 100");
            }
            _grades[(student, course)] = grade;
        }

        // TODO: Calculate GPA for student
        public double? CalculateGPA(TStudent student)
        {
            // Weighted by course credits
            // Return null if no grades

            double TotalPoints = 0;
            double TotalCredits = 0;

            foreach (var entry in _grades)
            {
                if (entry.Key.Item1.Equals(student))
                {
                    if (entry.Key.Item2 is ICourse course)
                    {
                        TotalPoints += entry.Value * course.Credits;
                        TotalCredits += course.Credits;
                    }
                }
            }
            if (TotalCredits == 0)
                return null;

            return TotalPoints / TotalCredits;

        }

        // TODO: Find top student in course
        public (TStudent student, double grade)? GetTopStudent(TCourse course)
        {
            // Return student with highest grade
            bool found = false;
            TStudent BestStudnet = default;
            double BestGrade = -1;

            foreach (var entry in _grades)
            {
                if (entry.Key.Item2.Equals(course))
                {
                    if (!found || entry.Value > BestGrade)
                    {
                        found = true;
                        BestStudnet = entry.Key.Item1;
                        BestGrade = entry.Value;
                    }
                }
            }
            if (!found) return null;
            return (BestStudnet, BestGrade);

        }
    }


    class Program
    {
        static void Main()
        {
            var student1 = new EngineeringStudent { StudentId = 1, Name = "Alice", Semester = 3 };
            var student2 = new EngineeringStudent { StudentId = 2, Name = "Bob", Semester = 1 };
            var student3 = new EngineeringStudent { StudentId = 3, Name = "Charlie", Semester = 4 };

            var course1 = new LabCourse
            {
                CourseCode = "LAB101",
                Title = "Basic Electronics Lab",
                Credits = 3,
                MaxCapacity = 2,
                RequiredSemester = 2
            };

            var course2 = new LabCourse
            {
                CourseCode = "LAB201",
                Title = "Advanced Robotics Lab",
                Credits = 4,
                MaxCapacity = 2,
                RequiredSemester = 3
            };

            var enrollment = new EnrollmentSystem<EngineeringStudent, LabCourse>();

            enrollment.EnrollStudent(student1, course1);
            enrollment.EnrollStudent(student2, course1); // fails prerequisite
            enrollment.EnrollStudent(student3, course1);
            enrollment.EnrollStudent(student1, course1); // duplicate
            enrollment.EnrollStudent(student3, course2);

            var gradeBook = new GradeBook<EngineeringStudent, LabCourse>();

            gradeBook.AddGrade(student1, course1, 85);
            gradeBook.AddGrade(student3, course1, 92);
            gradeBook.AddGrade(student3, course2, 88);

            Console.WriteLine("\nAlice GPA: " + gradeBook.CalculateGPA(student1));
            Console.WriteLine("Charlie GPA: " + gradeBook.CalculateGPA(student3));

            var top = gradeBook.GetTopStudent(course1);
            if (top != null)
                Console.WriteLine($"Top student in LAB101: {top.Value.student.Name} ({top.Value.grade})");
        }
    }


}