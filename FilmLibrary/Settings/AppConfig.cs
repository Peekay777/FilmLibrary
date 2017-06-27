using Microsoft.Extensions.Configuration;
using System.IO;

namespace FilmLibrary.Settings
{
    public class AppConfig<T> where T: class
    {
        private static AppConfig<T> _instance = null;

        private AppConfig()
        {
            Items = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(typeof(T).Name + ".json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build()
                .Get<T>();
        }

        public T Items { get; set; }

        public static AppConfig<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppConfig<T>();
                }
                return _instance;
            }
        }
    }
}
