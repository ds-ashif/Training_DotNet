using System;
using System.Collections.Generic;

namespace Students
{
    /// <summary>
    /// Student class implementing IMarks interface.
    /// </summary>
    public class Student:IMarks
    {
        /// <summary>
        /// Gets or sets the unique identifier of the student.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the student.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the marks obtained in Maths.
        /// </summary>
        public int MathsMarks { get; set; }

        /// <summary>
        /// Gets or sets the marks obtained in Science.
        /// </summary>
        public int ScienceMarks { get; set; }

        /// <summary>
        /// Gets or sets the marks obtained in English.
        /// </summary>
        public int EnglishMarks { get; set; }

        /// <summary>
        /// Gets or sets the rank of the student.
        /// </summary>
        public int Rank{get; set;}

        /// <summary>
        /// Initializes a new instance of the Student class with specified details.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="mathsMarks"></param>
        /// <param name="scienceMarks"></param>
        /// <param name="englishMarks"></param>
        public Student(int id, string name, int mathsMarks, int scienceMarks, int englishMarks)
        {
            Id = id;
            Name = name;
            MathsMarks = mathsMarks;
            ScienceMarks = scienceMarks;
            EnglishMarks = englishMarks;
        }

        /// <summary>
        /// Calculates the total marks obtained by the student.
        /// </summary>
        /// <returns></returns>
        public int totalMarks()
        {
            return MathsMarks + ScienceMarks + EnglishMarks;

        }

        

      
    }
}
