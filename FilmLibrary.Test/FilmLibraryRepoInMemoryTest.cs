using FilmLibrary.Data.InMemory;
using FilmLibrary.Models;
using System.Collections.Generic;
using Xunit;

namespace FilmLibrary.Test
{
    public class FilmLibraryRepoInMemoryTest
    {
        private static Film _exampleFilm1 = new Film()
        {
            Id = 0,
            Title = "Fight Club",
            Runtime = 139
        };
        private static Film _exampleFilm2 = new Film()
        {
            Id = 0,
            Title = "Dogville",
            Runtime = 178
        };

        [Theory(DisplayName = "Add a film")]
        [InlineData(0, 0, 1)]
        public void Add_film(int nextFilmId, int expectedOne, int expectedTwo)
        {
            // Arrange
            FilmLibraryRepoInMemory filmRepo = new FilmLibraryRepoInMemory(nextFilmId);

            // Act
            int actualOne = filmRepo.AddFilm(_exampleFilm1);
            int actualTwo = filmRepo.AddFilm(_exampleFilm2);

            // Assert
            Assert.Equal(expectedOne, actualOne);
            Assert.Equal(expectedTwo, actualTwo);
        }

        [Fact(DisplayName = "Get all films")]
        public void Get_all_films()
        {
            // Arrange
            FilmLibraryRepoInMemory filmRepo = new FilmLibraryRepoInMemory(0);
            filmRepo.AddFilm(_exampleFilm1);
            filmRepo.AddFilm(_exampleFilm2);

            Film film1 = new Film()
            {
                Id = 0,
                Title = "Fight Club",
                Runtime = 139
            };
            Film film2 = new Film()
            {
                Id = 1,
                Title = "Dogville",
                Runtime = 178
            };

            List<Film> expectedList = new List<Film>()
            {
                film1,
                film2
            };

            // Act
            List<Film> actualList = filmRepo.GetAllFilms();

            // Assert
            Assert.Equal<Film>(expectedList, actualList);
        }

        [Theory(DisplayName = "Get film by id")]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        public void Get_film_by_id(int id, int expectedId)
        {
            // Arrange
            FilmLibraryRepoInMemory filmRepo = new FilmLibraryRepoInMemory(0);
            filmRepo.AddFilm(_exampleFilm1);
            filmRepo.AddFilm(_exampleFilm2);

            // Act
            Film actualFilm = filmRepo.GetFilmById(id);

            // Assert
            Assert.Equal(expectedId, actualFilm.Id);
        }

        [Fact(DisplayName = "Update film")]
        public void Update_film()
        {
            // Arrange
            FilmLibraryRepoInMemory filmRepo = new FilmLibraryRepoInMemory(0);
            filmRepo.AddFilm(_exampleFilm1);
            bool expected = true;

            Film expectedFilm = new Film()
            {
                Id = 0,
                Title = "Fight Club: Extended",
                Runtime = 150
            };

            // Act
            bool actual = filmRepo.UpdateFilm(expectedFilm);
            Film actualFilm = filmRepo.GetFilmById(0);

            // Assert
            Assert.Equal(expected, actual);
            Assert.Equal<Film>(expectedFilm, actualFilm);
        }

        [Theory(DisplayName = "Delete film")]
        [InlineData(0, 1, true)]
        [InlineData(99, 2, false)]
        public void Delete_film(int id, int expectedCount, bool expected)
        {
            // Arrange
            FilmLibraryRepoInMemory filmRepo = new FilmLibraryRepoInMemory(0);
            filmRepo.AddFilm(_exampleFilm1);
            filmRepo.AddFilm(_exampleFilm2);

            // Act
            bool actual = filmRepo.DeleteFilm(id);
            int actualCount = filmRepo.GetAllFilms().Count;

            // Assert
            Assert.Equal(expected, actual);
            Assert.Equal(expectedCount, actualCount);
        }
    }
}
