using System;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Entry point for Library Management System.
    /// Provides menu-driven interaction for managing books.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application starting method.
        /// Displays menu options and executes user requests.
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Library Management System!");

            LibraryUtility library = new LibraryUtility();
            int choice;

            // Menu loop continues until exit option is chosen
            do
            {
                Console.WriteLine("\n1. Add Book");
                Console.WriteLine("2. Group Books by Genre");
                Console.WriteLine("3. Search Books by Author");
                Console.WriteLine("4. Total Books Count");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Collect book details
                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Enter Author: ");
                        string author = Console.ReadLine();

                        Console.Write("Genre: ");
                        string genre = Console.ReadLine();

                        Console.Write("Publication Year: ");
                        int year = int.Parse(Console.ReadLine());

                        // Add book record
                        library.AddBook(title, author, genre, year);
                        Console.WriteLine("Book added successfully.");
                        break;

                    case 2:
                        // Display grouped books
                        var grouped = library.GroupBooksByGenre();

                        foreach (var entry in grouped)
                        {
                            Console.WriteLine("\nGenre: " + entry.Key);

                            foreach (var book in entry.Value)
                            {
                                Console.WriteLine($" - {book.Title} by {book.Author}");
                            }
                        }
                        break;

                    case 3:
                        // Search books by author
                        Console.Write("Enter author name: ");
                        string searchAuthor = Console.ReadLine();

                        var booksByAuthor =
                            library.GetBooksByAuthor(searchAuthor);

                        if (booksByAuthor.Count == 0)
                        {
                            Console.WriteLine("No Book Found.");
                        }
                        else
                        {
                            foreach (var book in booksByAuthor)
                            {
                                Console.WriteLine(
                                    $"{book.Title} ({book.Genre}, {book.PublicationYear})");
                            }
                        }
                        break;

                    case 4:
                        // Display total books count
                        Console.WriteLine("Total Books: " +
                            library.GetTotalBooksCount());
                        break;

                    default:
                        // Handles invalid menu choice
                        Console.WriteLine("Invalid Choice.");
                        break;
                }

            } while (choice != 5);
        }
    }
}
