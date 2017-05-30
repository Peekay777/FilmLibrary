using Xunit;
using FilmLibrary.TheMovieDatabaseAPI;
using FilmLibrary.TheMovieDatabaseAPI.Models;

namespace FilmLibrary.Test
{
    public class TheMovieDbApiTest
    {
        [Fact]
        public async void Test()
        {
            TheMovieDbApi mdb = new TheMovieDbApi("api", "proxy", "username", "password");
            MovieResults mr = await mdb.FindMovie("Fight Club");
        }
    }
}
