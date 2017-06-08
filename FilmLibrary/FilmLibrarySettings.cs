using Microsoft.Extensions.Configuration;
using System.IO;

namespace FilmLibrary
{
    public class FilmLibrarySettings
    {
        private static FilmLibrarySettings _settings = null;

        private FilmLibrarySettings()
        {
            ConfigItems = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("filmlibrarysettings.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build()
                .Get<ConfigItem>();
        }

        public static FilmLibrarySettings Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = new FilmLibrarySettings();
                }
                return _settings;
            }
        }

        public ConfigItem ConfigItems { get; set; }
    }

    public class ConfigItem
    {
        
    }
}
