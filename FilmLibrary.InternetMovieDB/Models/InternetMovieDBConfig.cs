using System;
using System.Collections.Generic;
using System.Text;

namespace FilmLibrary.InternetMovieDB.Models
{
    public class InternetMovieDBConfig
    {
        public string Themoviedb_apikey { get; set; }
        public string BaseUrl { get; set; } = "https://api.themoviedb.org";
        public SettingsProxy Proxy { get; set; }
        public SettingsUrl Urls { get; set; } = new SettingsUrl();
    }

    public class SettingsProxy
    {
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class SettingsUrl
    {
        public string SearchMovie { get; set; } = "3/search/movie";
        public string GetMovie { get; set; } = "3/movie";
        public string Configuration { get; set; } = "3/configuration";
    }
}