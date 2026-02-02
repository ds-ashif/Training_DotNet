using System;
using System.Collections.Generic;

namespace Students
{
    /// <summary>
    /// Interface representing marks in different subjects.
    /// </summary>
    public interface IMarks
    {
        /// <summary>
        /// Gets the marks obtained in Maths.
        /// </summary>
        int MathsMarks{get;}

        /// <summary>
        /// Gets the marks obtained in Science.
        /// </summary>
        int ScienceMarks{get;}

        /// <summary>
        /// Gets the marks obtained in English.
        /// </summary>
        int EnglishMarks{get;}
    }
}