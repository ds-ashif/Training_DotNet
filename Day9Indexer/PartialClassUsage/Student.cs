using System;
using System.Collections.Generic;
using System.Text;

namespace PartialClassUsage
{
    /// <summary>
    /// Represents a student with a roll number, name, address, and associated books.
    /// This is the main partial class containing core properties and the indexer.
    /// </summary>
    public partial class Student
    {
        public int RollNo { get; set; } // Auto-implemented property for Roll Number
        public string Name { get; set; } // Auto-implemented property for Name

        private string address; // Backing field for Address property
        public string Address // Property for Address with explicit get/set
        {
            get { return address; }
            set { address = value; }
        }

        private List<string> Books = new List<string>(); // List to hold book names

        /// <summary>
        /// Indexer to access books by index with validation.
        /// </summary>
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < Books.Count)
                {
                    return Books[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
            set
            {
                if (index >= 0 && index < Books.Count)
                {
                    Books[index] = value;
                }
                else if (index == Books.Count) // Allow adding a new book at the end
                {
                    Books.Add(value);
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
        }

        public void PrintMainClass()
        {
            Console.WriteLine("This is Main Class method");
        }
    }
}
