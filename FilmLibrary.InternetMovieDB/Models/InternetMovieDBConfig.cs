using System;
using System.Collections.Generic;
using System.Text;

namespace FilmLibrary.InternetMovieDB.Models
{
    public class InternetMovieDBConfig
    {
        public string Themoviedb_apikey { get; set; }
        public string BaseUrl { get; set; } = "https://api.themoviedb.org";
        public string SearchMovieUrl { get; set; } = "3/search/movie";
        public string GetMovieUrl { get; set; } = "3/movie";
        public SettingsProxy Proxy { get; set; }
    }

    public class SettingsProxy
    {
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}