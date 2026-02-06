using System;
using System.Collections.Generic;

namespace StudentGradeManagementSystem
{
    /// <summary>
    /// Handles student record management and grade calculations.
    /// </summary>
    public class SchoolManager
    {
        #region Fields

        /// <summary>
        /// Stores all students.
        /// </summary>
        private List<Student> students = new List<Student>();

        /// <summary>
        /// Counter for auto-generating student IDs.
        /// </summary>
        private int idCounter = 1;

        #endregion

        #region Add Student

        /// <summary>
        /// Adds a student with auto-generated ID.
        /// </summary>
        /// <param name="name">Student name</param>
        /// <param name="gradeLevel">Student grade level</param>
        public void AddStudent(string name, string gradeLevel)
        {
            students.Add(new Student
            {
                StudentId = idCounter++,
                Name = name,
                GradeLevel = gradeLevel
            });
        }

        #endregion

        #region Add Grade

        /// <summary>
        /// Adds or updates subject grade for a student.
        /// Grade must be between 0 and 100.
        /// </summary>
        /// <param name="studentId">Student ID</param>
        /// <param name="subject">Subject name</param>
        /// <param name="grade">Grade value</param>
        public void AddGrade(int studentId, string subject, double grade)
        {
            if (grade < 0 || grade > 100)
            {
                Console.WriteLine("Invalid grade value.");
                return;
            }

            foreach (var student in students)
            {
                if (student.StudentId == studentId)
                {
                    student.Subjects[subject] = grade;
                    return;
                }
            }
        }

        #endregion

        #region Group Students by Grade Level

        /// <summary>
        /// Groups students based on grade level.
        /// </summary>
        /// <returns>Sorted dictionary of grade levels</returns>
        public SortedDictionary<string, List<Student>> GroupStudentsByGradeLevel()
        {
            SortedDictionary<string, List<Student>> grouped = new SortedDictionary<string, List<Student>>();

            foreach (var student in students)
            {
                if (!grouped.ContainsKey(student.GradeLevel))
                    grouped[student.GradeLevel] = new List<Student>();

                grouped[student.GradeLevel].Add(student);
            }

            return grouped;
        }

        #endregion

        #region Student Average

        /// <summary>
        /// Calculates average grade of a student.
        /// </summary>
        /// <param name="studentId">Student ID</param>
        /// <returns>Average grade</returns>
        public double CalculateStudentAverage(int studentId)
        {
            foreach (var student in students)
            {
                if (student.StudentId == studentId)
                {
                    if (student.Subjects.Count == 0)
                        return 0;

                    double total = 0;

                    foreach (var grade in student.Subjects.Values)
                        total += grade;

                    return total / student.Subjects.Count;
                }
            }

            return 0;
        }

        #endregion

        #region Subject Averages

        /// <summary>
        /// Calculates average grade per subject across all students.
        /// </summary>
        /// <returns>Dictionary of subject averages</returns>
        public Dictionary<string, double> CalculateSubjectAverages()
        {
            Dictionary<string, double> totals = new Dictionary<string, double>();
            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (var student in students)
            {
                foreach (var entry in student.Subjects)
                {
                    if (!totals.ContainsKey(entry.Key))
                    {
                        totals[entry.Key] = 0;
                        counts[entry.Key] = 0;
                    }

                    totals[entry.Key] += entry.Value;
                    counts[entry.Key]++;
                }
            }

            Dictionary<string, double> averages = new Dictionary<string, double>();

            foreach (var subject in totals.Keys)
                averages[subject] = totals[subject] / counts[subject];

            return averages;
        }

        #endregion

        #region Top Performers

        /// <summary>
        /// Returns top N students based on average grade.
        /// </summary>
        /// <param name="count">Number of students to return</param>
        public List<Student> GetTopPerformers(int count)
        {
            List<(Student student, double avg)> averages =
                new List<(Student, double)>();

            foreach (var student in students)
            {
                double avg = CalculateStudentAverage(student.StudentId);
                averages.Add((student, avg));
            }

            averages.Sort((a, b) => b.avg.CompareTo(a.avg));

            List<Student> result = new List<Student>();

            for (int i = 0; i < count && i < averages.Count; i++)
                result.Add(averages[i].student);

            return result;
        }

        #endregion
    }
}
