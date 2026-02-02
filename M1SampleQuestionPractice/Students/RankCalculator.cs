using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    /// <summary>
    /// Delegate to notify remarks for a student.
    /// </summary>
    /// <param name="student"></param>
    public delegate void RemarkDelegate(Student student);

    public class RankCalculator
    {
        /// <summary>
        /// Calculates ranks for the given list of students and notifies remarks using the provided Action delegate.
        /// </summary>
        /// <param name="students"></param>
        /// <param name="remarkNotifier"></param>
        public void CalculateRanks(List<Student> students,Action<Student> remarkNotifier)
        {
            var rankedStudents = students.OrderByDescending(s => s.totalMarks()).ToList();
            int rank=1;

            foreach(var student in rankedStudents)
            {
                student.Rank=rank++;
                remarkNotifier?.Invoke(student);
            }
        }
    }
}