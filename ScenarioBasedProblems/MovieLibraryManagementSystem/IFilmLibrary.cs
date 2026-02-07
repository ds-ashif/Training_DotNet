using System;
using System.Collections.Generic;


namespace MovieLibraryManagementSystem
{
    // Interface defining library operations
    public interface IFilmLibrary
    {
        void AddFilm(IFilm Film);
        void RemoveFilm(string title);
        List<IFilm> GetFilms();
        List<IFilm> SearchFilms(string query);
        int GetTotalFilmCount();

    }
}