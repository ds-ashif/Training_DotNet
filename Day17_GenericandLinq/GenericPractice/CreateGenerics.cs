using System;
using System.Collections.Generic;
using System.Text;

namespace GenericPractice
{
    #region Generic Class

    /// <summary>
    /// A generic class used to demonstrate how generics work in C#.
    /// The type parameter <typeparamref name="T"/> can represent
    /// any data type (value type or reference type).
    /// </summary>
    /// <typeparam name="T">
    /// The data type that will be supplied at runtime.
    /// </typeparam>
    public class CreateGenerics<T>
    {
        /// <summary>
        /// Holds a value of the generic type <typeparamref name="T"/>.
        /// </summary>
        public T value { get; set; }

        /// <summary>
        /// Returns the type information of the generic parameter <typeparamref name="T"/>.
        /// </summary>
        /// <param name="t">
        /// An optional parameter of type <typeparamref name="T"/>.
        /// This parameter is not used in the current implementation
        /// and exists only for demonstration purposes.
        /// </param>
        /// <returns>
        /// A string representing the fully qualified name of type <typeparamref name="T"/>.
        /// </returns>
        public string GetType(T? t)
        {
            return typeof(T).ToString();
        }
    }

    #endregion

    #region Domain Models

    /// <summary>
    /// Represents a base student entity.
    /// Acts as a parent class for different student categories.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Gets or sets the unique identifier of the student.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the full name of the student.
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// Represents an undergraduate student.
    /// Inherits common student properties from <see cref="Student"/>.
    /// </summary>
    public class UgStudent : Student
    {
        /// <summary>
        /// Gets or sets the high school marks of the undergraduate student.
        /// </summary>
        public int HighSchoolMarks { get; set; }
    }

    /// <summary>
    /// Represents a postgraduate student.
    /// Inherits common student properties from <see cref="Student"/>.
    /// </summary>
    public class PgStudent : Student
    {
        /// <summary>
        /// Gets or sets the undergraduate marks of the postgraduate student.
        /// </summary>
        public int UgMarks { get; set; }
    }

    #endregion
}
