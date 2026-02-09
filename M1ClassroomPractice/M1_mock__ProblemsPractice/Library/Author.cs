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
    /// Represents an author with name and country.
    /// </summary>
    public class Author
    {
        // Author's name
        public string AuthorName { get; set; }
        // Author's country
        public string Country { get; set; }

        /// <summary>
        /// Constructor initializes author details.
        /// </summary>

        public Author(string authorName, string country)
        {
            AuthorName = authorName;
            Country = country;
        }

    }
}