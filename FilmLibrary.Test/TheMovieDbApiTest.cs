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
            string api = "";
            //TheMovieDbApi mdb = new TheMovieDbApi("api", "proxy", "username", "password");
            TheMovieDbApi mdb = new TheMovieDbApi(api);

            MovieSearch ms = await mdb.FindMovie("Fight Club");
            Movie m = await mdb.GetMovie(ms.results[0].id);
        }
    }
}
