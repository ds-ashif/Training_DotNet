namespace LibraryManagementSystem
{
    /// <summary>
    /// Provides operations for managing books in the library.
    /// supports adding books, grouping by genre, searching by author, count of books
    /// </summary>
    public  class LibraryUtility
    {
        
        /// <summary>
        /// Stores all books with an auto-generated unique ID.
        /// Key = Book ID, Value = Book details.
        /// </summary>
        private  SortedDictionary<int,Book> books = new SortedDictionary<int, Book>();

         /// <summary>
        /// Maintains next book ID for auto-increment.
        /// </summary>
        private int nextBookId = 1;
         
        /// <summary>
        /// Adds a new book record to the library.
        /// Book ID is generated automatically.
        /// </summary>
        /// <param name="title">Book Title</param>
        /// <param name="author">Book author.</param>
        /// <param name="genre">Book genre/category.</param>
        /// <param name="year">Publication year.</param>
        public void AddBook(string title, string author, string genre, int year)
        {
            // Add book and increment ID counter
            
            books.Add(nextBookId++, new Book(){Title = title, Author = author, Genre = genre, PublicationYear = year});
        }

        /// <summary>
        /// Groups books by genre in alphabetical order.
        /// </summary>
        /// <returns>
        /// Dictionary where key is genre and value is list of books belonging to that genre.
        /// </returns>

        public SortedDictionary<string, List<Book>> GroupBooksByGenre()
        {
            SortedDictionary<string, List<Book>> groupedBooks = new SortedDictionary<string, List<Book>>();

            foreach(var book in books.Values)
            {
                if (!groupedBooks.ContainsKey(book.Genre))
                {
                    groupedBooks[book.Genre] = new List<Book>();
                }
                groupedBooks[book.Genre].Add(book);
            }
            return groupedBooks;
        }

        /// <summary>
        /// Retrieves all books written by the specified author.
        /// Search is case-insensitive.
        /// </summary>
        /// <param name="author">Author name to search.</param>
        /// <returns>List of books by the author.</returns>
        public List<Book> GetBooksByAuthor(string author)
        {
            List<Book> authorBooks = new List<Book>();

            foreach(var book in books.Values)
            {
                if(book.Author.ToLower() == author.ToLower())
                {
                    authorBooks.Add(book);
                }
            }
            return authorBooks;
        }

        /// <summary>
        /// Returns total number of books in library.
        /// </summary>
        public int GetTotalBooksCount()
        {
            return books.Count;
        }
        
    }
}