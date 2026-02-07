using System;
using System.Collections.Generic;
using System.Linq;


namespace MovieLibraryManagementSystem
{
    public class Program
    {
        /// <summary>
        /// Entry point of Application
        /// </summary>
        static void Main()
        {
            // Instance of IFilmLibrary
            IFilmLibrary library = new FilmLibrary();

            // -------- Test Case 1: Adding films in list --------
            library.AddFilm(new Film("Inception", "Christopher Nolan", 2010));
            library.AddFilm(new Film("Interstellar", "Christopher Nolan", 2014));
            library.AddFilm(new Film("Titanic", "James Cameron", 1997));

            Console.WriteLine("Films added successfully\n");

            // -------- Test Case 2 --------
            Console.WriteLine("TEST CASE 2: Displaying all films");
            foreach(var item in library.GetFilms())
            {
                Film film = (Film)item;
                Console.WriteLine($"{film.Title} | {film.Director} | {film.Year}");
            }

            // -------- Test Case 3 --------
            Console.WriteLine("TEST CASE 3: Search films by director 'Nolan' ");

            var results =  library.SearchFilms("Nolan");
            foreach(var item in results)
            {
                Film film = (Film)item;
                Console.WriteLine($"{film.Title} | {film.Director}");
            }

            Console.WriteLine();

            // -------- Test Case 4 --------
            Console.WriteLine("TEST CASE 4: Removing film 'Titanic'");
            library.RemoveFilm("Titanic");

            Console.WriteLine("Remaining films:");
            foreach (var item in library.GetFilms())
            {
                Film film = (Film)item;
                Console.WriteLine(film.Title);
            }
            Console.WriteLine();

            // -------- Test Case 5 --------
            Console.WriteLine("TEST CASE 5: Total film count");
            Console.WriteLine("Total Films: " + library.GetTotalFilmCount());

        }
 
    }
}