using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FilmLibrary.InternetMovieDB.TheMovieDatabase
{
    public class TheMovieDB<MovieSearchResult, MovieResult> : IMovieService<MovieSearchResult, MovieResult>
    {
        private IHttpClient _client;
        private string _apiKey;
        private string _baseUrl;        // "https://api.themoviedb.org";
        private string _searchMovieUrl; // "3/search/movie";
        private string _getMovieUrl;    // "3/movie";

        public TheMovieDB(IHttpClient client, string apiKey, string baseUrl, string searchMovieUrl, string getMovieUrl)
        {
            _client = client;
            _apiKey = apiKey;
            _baseUrl = baseUrl;
            _searchMovieUrl = searchMovieUrl;
            _getMovieUrl = getMovieUrl;
        }

        public async Task<MovieResult> GetMovieAsync(string movieId)
        {
            Uri baseUri = new Uri(_baseUrl);
            Uri getMovieUrl = new Uri(baseUri, _getMovieUrl + "/" + movieId);
            var url = new UriBuilder(getMovieUrl);

            using (var content = new FormUrlEncodedContent(
                new KeyValuePair<string, string>[]{
                    new KeyValuePair<string, string>("api_key", _apiKey),
                    new KeyValuePair<string, string>("language", "en-US")
            }))
            {
                url.Query = await content.ReadAsStringAsync();
            }

            string responseText = await _client.MakeRequest(url.Uri);

            return JsonConvert.DeserializeObject<MovieResult>(responseText);
        }

        public async Task<MovieSearchResult> MovieSearchAsync(string query)
        {
            Uri baseUri = new Uri(_baseUrl);
            Uri searchMovieUrl = new Uri(baseUri, _searchMovieUrl);
            var url = new UriBuilder(searchMovieUrl);

            using (var content = new FormUrlEncodedContent(
                new KeyValuePair<string, string>[]{
                    new KeyValuePair<string, string>("api_key", _apiKey),
                    new KeyValuePair<string, string>("language", "en-US"),
                    new KeyValuePair<string, string>("page", "1"),
                    new KeyValuePair<string, string>("include_adult", "false"),
                    new KeyValuePair<string, string>("query", query),
            }))
            {
                url.Query = await content.ReadAsStringAsync();
            }

            string responseText = await _client.MakeRequest(url.Uri);

            return JsonConvert.DeserializeObject<MovieSearchResult>(responseText);
        }
    }
}
