/**
Q8. Library - Composition (Has-A Relationship)
A library stores books along with author information.
Requirements:
•	Create class Author: AuthorName, Country.
•	Create class Book: Title, Price, and an Author object.
Task: Create 2 books with authors and print in a clean formatted output.
**/

using System;
using System.Net;
namespace Library
{
     /// <summary>
    /// Represents a book.
    /// A Book HAS an Author object (Composition).
    /// </summary>
    public class Book
    {
        // Book title
        public string Title { get; set; }

        // Book price
        public double Price { get; set; }

        // Author object associated with book
        public Author author {get; set;}

        /// <summary>
        /// Constructor initializes book details including author.
        /// </summary>
        
        public Book(string title, double price, Author author)
        {
            Title = title;
            Price = price;
            this.author = author;
        }

         /// <summary>
        /// Displays formatted book information.
        /// </summary>
        
        public void Display()
        {
            Console.WriteLine("Book Details");
            Console.WriteLine($"Title   : {Title}");
            Console.WriteLine($"Price   : Rs. {Price}");
            Console.WriteLine($"Author  : {author.AuthorName}");
            Console.WriteLine($"Country : {author.Country}");
            Console.WriteLine("----------------------------------");
        }
    }
}