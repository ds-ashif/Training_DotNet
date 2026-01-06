using System;
using System.Collections.Generic;
using System.Text;

namespace PartialClassUsage
{
    /// <summary>
    /// Partial class extension for Student.
    /// Demonstrates how to extend functionality across multiple files.
    /// </summary>
    public partial class Student
    {
        public void PrintPartial()
        {
            Console.WriteLine("This is Partial Class method");
        }
    }

}
