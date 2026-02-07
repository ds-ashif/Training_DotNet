using System;
using System.Collections.Generic;
using System.Linq;


namespace MovieLibraryManagementSystem
{
    // Film library implementing management logic
    public class FilmLibrary : IFilmLibrary
    {
        private List<IFilm> _films = new List<IFilm>();

        // Adds film to library
        public void AddFilm(IFilm film)
        {
            _films.Add(film);
        }

        // Removes film by title
        public void RemoveFilm(string title)
        {
            _films.RemoveAll(f => f.Title == title); 
        }

        // Returns all films
        public List<IFilm> GetFilms()
        {
            List<IFilm> films = new List<IFilm>();

            foreach(var film in _films)
            {
                if(film != null)
                {
                    films.Add(film);
                }
            }
            return films;
        }
         // Searches films by title or director
        public List<IFilm> SearchFilms(string query)
        {
            return _films
                .Where(f => f.Title.Contains(query, StringComparison.OrdinalIgnoreCase) || 
                (f is Film film && film.Director.Contains(query, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        // Returns total film count
        public int GetTotalFilmCount()
        {
            return _films.Count();
        }
    }
}