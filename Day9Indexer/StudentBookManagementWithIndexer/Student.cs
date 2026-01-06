using System;
using System.Collections.Generic;


namespace StudentBookManagementWithIndexer
{
    /// <summary>
    /// Represents a student with a roll number, name, address, and associated books.
    /// Demonstrates the use of indexers to access a private List collection.
    /// </summary>
    /// <remarks>
    /// Address and Books are privately held data. Properties and indexers provide
    /// controlled access to these fields from outside the class.
    /// </remarks>
    public class Student
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
        /// <param name="index">Zero-based index of the book</param>
        /// <returns>The book name at the specified index</returns>
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
                    Books[index] = value; // Update existing book
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
    }
}
