using FilmLibrary.InternetMovieDB;
using FilmLibrary.InternetMovieDB.TheMovieDatabase;
using FilmLibrary.InternetMovieDB.TheMovieDatabase.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Xunit;

namespace FilmLibrary.Test
{
    public class InternetMovieDBTest
    {
        [Fact]
        public async void Test()
        {
            string baseUrl = "https://api.themoviedb.org";
            string searchMovieUrl = "3/search/movie";
            string getMovieUrl = "3/movie";

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build()
                .Get<AppSettings>();

            IHttpClient httpClient;
            if (!string.IsNullOrEmpty(config.Proxy_url) && 
                !string.IsNullOrEmpty(config.Proxy_username) && 
                !string.IsNullOrEmpty(config.Proxy_password))
            {
                httpClient = new TheMovieDBHttpClient(config.Proxy_url, config.Proxy_username, config.Proxy_password);
            }
            else
            {
                httpClient = new TheMovieDBHttpClient();
            }

            IMovieService<MovieSearchResult, MovieResult> movieService = new TheMovieDB<MovieSearchResult, MovieResult>(
                httpClient,
                config.Themoviedb_apikey,
                baseUrl,
                searchMovieUrl,
                getMovieUrl);

            MovieSearchResult msr = await movieService.MovieSearchAsync("Fight Club");
            MovieResult mr = await movieService.GetMovieAsync(msr.results[0].id.ToString());
        }
    }
}
