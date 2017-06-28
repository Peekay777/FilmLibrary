using FilmLibrary.Data;
using FilmLibrary.Data.Sql;
using FilmLibrary.Models;
using FilmLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace FilmLibrary.Test
{
    public class FilmLibraryRepoSQLiteTest
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

        //[Fact]
        //public void Test()
        //{
        //    //var options = new DbContextOptionsBuilder<FilmLibraryContext>()
        //    //    .UseInMemoryDatabase($"database{Guid.NewGuid()}")
        //    //    .Options;

        //    var options = new DbContextOptionsBuilder<FilmLibraryContext>()
        //        .UseSqlite(AppConfig<FilmLibraryConfig>.Instance.Items.ConnectionString)
        //        .Options;

        //    using (var context = new FilmLibraryContext(options))
        //    {
        //        var db = new FilmLibrarySQLite(context);
        //        //db.AddFilm(_exampleFilm1);
        //        //db.Commit();
        //        db.UpdateFilm(new Film {
        //            Id = 1,
        //            Title ="Fighty Club"
        //        });

        //        Assert.Equal(_exampleFilm1, db.GetFilmById(1));
        //    }
        //}

        [Theory(DisplayName = "Add films")]
        [InlineData(1, 2)]
        public void Add_film(int expectedOne, int expectedTwo)
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FilmLibraryContext>()
                .UseInMemoryDatabase($"database{Guid.NewGuid()}")
                .Options;

            int actualOne, actualTwo;

            // Act
            using (var context = new FilmLibraryContext(options))
            {
                var db = new FilmLibraryRepoSQLite(context);
                actualOne = db.AddFilm(_exampleFilm1);
                actualTwo = db.AddFilm(_exampleFilm2);
            }

            // Assert
            Assert.Equal(expectedOne, actualOne);
            Assert.Equal(expectedTwo, actualTwo);
        }

        [Fact(DisplayName = "Get all films")]
        public void Get_all_films()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FilmLibraryContext>()
                .UseInMemoryDatabase($"database{Guid.NewGuid()}")
                .Options;

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

            using (var context = new FilmLibraryContext(options))
            {
                var db = new FilmLibraryRepoSQLite(context);
                db.AddFilm(film1);
                db.AddFilm(film2);

                // Act
                List<Film> actualList = db.GetAllFilms();

                // Assert
                Assert.Equal<Film>(expectedList, actualList);
            }



        }

        [Theory(DisplayName = "Get film by id")]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void Get_film_by_id(int id, int expectedId)
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FilmLibraryContext>()
                .UseInMemoryDatabase($"database{Guid.NewGuid()}")
                .Options;

            using (var context = new FilmLibraryContext(options))
            {
                var db = new FilmLibraryRepoSQLite(context);
                db.AddFilm(_exampleFilm1);
                db.AddFilm(_exampleFilm2);



                // Act
                Film actualFilm = db.GetFilmById(id);

                // Assert
                Assert.Equal(expectedId, actualFilm.Id);
            }
        }

        [Fact(DisplayName = "Update film")]
        public void Update_film()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FilmLibraryContext>()
                .UseInMemoryDatabase($"database{Guid.NewGuid()}")
                .Options;

            bool expected = true;

            using (var context = new FilmLibraryContext(options))
            {
                var db = new FilmLibraryRepoSQLite(context);
                db.AddFilm(_exampleFilm1);




                Film expectedFilm = new Film()
                {
                    Id = 1,
                    Title = "Fight Club: Extended",
                    Runtime = 150
                };

                // Act
                bool actual = db.UpdateFilm(expectedFilm);
                Film actualFilm = db.GetFilmById(1);

                // Assert
                Assert.Equal(expected, actual);
                Assert.Equal<Film>(expectedFilm, actualFilm);

            }
        }

        [Theory(DisplayName = "Delete film")]
        [InlineData(1, 1, true)]
        [InlineData(99, 2, false)]
        public void Delete_film(int id, int expectedCount, bool expected)
        {
            // Arrange
            var options = new DbContextOptionsBuilder<FilmLibraryContext>()
                .UseInMemoryDatabase($"database{Guid.NewGuid()}")
                .Options;

            using (var context = new FilmLibraryContext(options))
            {
                var db = new FilmLibraryRepoSQLite(context);
                db.AddFilm(_exampleFilm1);
                db.AddFilm(_exampleFilm2);

                // Act
                bool actual = db.DeleteFilm(id);
                int actualCount = db.GetAllFilms().Count;

                // Assert
                Assert.Equal(expected, actual);
                Assert.Equal(expectedCount, actualCount);
            }
        }
    }
}
