using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilmLibrary.InternetMovieDB
{
    public class InternetMovieDBSettings
    {
        private static InternetMovieDBSettings _settings = null;

        public ConfigItem ConfigItems { get; set; }

        private InternetMovieDBSettings()
        {
            ConfigItems = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("internetmoviedbsettings.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build()
                .Get<ConfigItem>();
        }

        public static InternetMovieDBSettings Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = new InternetMovieDBSettings();
                }
                return _settings;
            }
        }
    }

    public class ConfigItem
    {
        public string Themoviedb_apikey { get; set; }
        public string BaseUrl { get; set; } = "https://api.themoviedb.org";
        public string SearchMovieUrl { get; set; } = "3/search/movie";
        public string GetMovieUrl { get; set; } = "3/movie";
        public ConfigItemProxy Proxy { get; set; }
    }

    public class ConfigItemProxy
    {
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
