using FilmLibrary.TheMovieDatabaseAPI.Client;
using FilmLibrary.TheMovieDatabaseAPI.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace FilmLibrary.TheMovieDatabaseAPI
{
    public class TheMovieDbApi
    {
        private static string _apiKey;
        private static TmdbHttpClient _httpTmdbHttpClient;

        public TheMovieDbApi(string apiKey)
        {
            _apiKey = apiKey;
            _httpTmdbHttpClient = new TmdbHttpClient();
        }

        public TheMovieDbApi(string apiKey, string proxyUrl, string username, string password)
        {
            _apiKey = apiKey;

            ProxyConfig proxyConfig = new ProxyConfig()
            {
                ProxyUrl = proxyUrl,
                Username = username,
                Password = password
            };
            _httpTmdbHttpClient = new TmdbHttpClient(proxyConfig);
        }

        public async Task<MovieSearch> FindMovie(string query)
        {
            string responseText = await _httpTmdbHttpClient.MovieSearch(_apiKey, query);
            return JsonConvert.DeserializeObject<MovieSearch>(responseText);
        }

        public async Task<Movie> GetMovie(int movieId)
        {
            string responseText = await _httpTmdbHttpClient.GetMovie(_apiKey, movieId);
            return JsonConvert.DeserializeObject<Movie>(responseText);
        }
    }
}
