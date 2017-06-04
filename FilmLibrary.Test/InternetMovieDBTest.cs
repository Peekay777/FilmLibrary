using FilmLibrary.InternetMovieDB;
using FilmLibrary.InternetMovieDB.TheMovieDatabase;
using FilmLibrary.InternetMovieDB.TheMovieDatabase.Models;
using Xunit;

namespace FilmLibrary.Test
{
    public class InternetMovieDBTest
    {
        [Fact]
        public async void Test()
        {
            string apiKey = "";
            string baseUrl = "https://api.themoviedb.org";
            string searchMovieUrl = "3/search/movie";
            string getMovieUrl = "3/movie";

            IHttpClient httpClient = new TheMovieDBHttpClient();
            IMovieService<MovieSearchResult, MovieResult> movieService = new TheMovieDB<MovieSearchResult, MovieResult>(
                httpClient,
                apiKey,
                baseUrl,
                searchMovieUrl,
                getMovieUrl);

            MovieSearchResult msr = await movieService.MovieSearchAsync("Fight Club");
            MovieResult mr = await movieService.GetMovieAsync(msr.results[0].id.ToString());
        }
    }
}
