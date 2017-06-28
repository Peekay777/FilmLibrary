using FilmLibrary.Models;
using System.Collections.Generic;

namespace FilmLibrary.Data
{
    public interface IFilmLibraryRepo
    {
        Film GetFilmById(int id);
        List<Film> GetAllFilms();
        int AddFilm(Film film);
        bool UpdateFilm(Film film);
        bool DeleteFilm(int id);
    }
}
