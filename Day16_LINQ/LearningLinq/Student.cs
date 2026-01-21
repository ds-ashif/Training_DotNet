using System;

#region Student Model

/// <summary>
/// Represents a student entity containing
/// basic identification details and academic marks.
/// </summary>
public class Student
{
    /// <summary>
    /// Gets or sets the roll number of the student.
    /// This value uniquely identifies a student.
    /// </summary>
    public int RollNo { get; set; } // Property for Roll Number

    /// <summary>
    /// Gets or sets the full name of the student.
    /// </summary>
    public string Name { get; set; } // Property for Name

    /// <summary>
    /// Gets or sets the marks obtained in English.
    /// </summary>
    public double EnglishMarks { get; set; } // Property for English Marks

    /// <summary>
    /// Gets or sets the marks obtained in Mathematics.
    /// </summary>
    public double MathMarks { get; set; } // Property for Math Marks

    /// <summary>
    /// Gets or sets the marks obtained in Hindi.
    /// </summary>
    public double HindiMarks { get; set; } // Property for Hindi Marks
}

#endregion
