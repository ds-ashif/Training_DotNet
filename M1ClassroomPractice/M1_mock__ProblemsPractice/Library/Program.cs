/**
Q8. Library - Composition (Has-A Relationship)
A library stores books along with author information.
Requirements:
•	Create class Author: AuthorName, Country.
•	Create class Book: Title, Price, and an Author object.
Task: Create 2 books with authors and print in a clean formatted output.
**/

using System;
namespace Library
{
    /// <summary>
    /// Entry point of Library application.
    /// </summary>
    class Program
    {
        static void Main()
        {
            Author author1 = new Author("J.K. Rowling", "United Kingdom");
            Author author2 = new Author("George Orwell", "United Kingdom");

            // Create Book objects using authors
            Book book1 = new Book("Harry Potter", 99, author1);
            Book book2 = new Book("1984", 399, author2);

            // Display book details
            book1.Display();
            book2.Display();

        }
    }
}