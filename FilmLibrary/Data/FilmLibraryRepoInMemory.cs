using FilmLibrary.Models;
using System;
using System.Collections.Generic;

namespace FilmLibrary.Data
{
    public class FilmLibraryRepoInMemory : IFilmLibraryRepo
    {
        private List<Film> _films;
        private int _nextFilmId;

        public FilmLibraryRepoInMemory(int nextFilmId)
        {
            _nextFilmId = nextFilmId;
            _films = new List<Film>();
        }

        public int AddFilm(Film film)
        {
            film.Id = _nextFilmId++;
            _films.Add(film);

            return film.Id;
        }

        public bool Commit()
        {
            throw new NotImplementedException();
        }

        public bool DeleteFilm(int id)
        {
            return _films.RemoveAll(f => f.Id == id) > 0 ? true : false;
        }

        public List<Film> GetAllFilms()
        {
            return _films;
        }

        public Film GetFilmById(int id)
        {
            return _films.Find(f => f.Id == id);
        }

        public bool UpdateFilm(Film film)
        {
            int index = _films.FindIndex(f => f.Id == film.Id);
            if (index >= 0)
            {
                _films[index] = film;
                return true;
            }
            return false;
        }
    }
}
