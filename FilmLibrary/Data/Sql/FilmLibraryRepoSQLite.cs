using FilmLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FilmLibrary.Data.Sql
{
    public class FilmLibraryRepoSQLite : IFilmLibraryRepo
    {
        private FilmLibraryContext _context = null;

        public FilmLibraryRepoSQLite(FilmLibraryContext context)
        {
            _context = context;
        }

        public int AddFilm(Film film)
        {
            _context.Films.Add(film);
            Commit();
            return film.Id;
        }

        private int Commit()
        {
            return _context.SaveChanges();
        }

        public bool DeleteFilm(int id)
        {
            Film film = GetFilmById(id);
            if (film != null)
            {
                _context.Films.Remove(film);
                return Commit() >= 0;
            }
            return false;
        }

        public List<Film> GetAllFilms()
        {
            return _context.Films.ToList<Film>();
        }

        public Film GetFilmById(int id)
        {
            return _context.Films
                .Where(f => f.Id == id)
                .DefaultIfEmpty(null)
                .FirstOrDefault();
        }

        public bool UpdateFilm(Film film)
        {
            Film oldFilm = GetFilmById(film.Id);
            if (oldFilm != null)
            {
                foreach (var prop in typeof(Film).GetProperties())
                {
                    if (prop.Name != "Id")
                    {
                        prop.SetValue(
                            oldFilm,
                            prop.GetValue(film));
                    }
                }
                return Commit() >= 0;
            }

            return false;
        }
    }
}
