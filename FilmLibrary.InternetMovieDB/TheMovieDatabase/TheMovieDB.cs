using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FilmLibrary.InternetMovieDB.TheMovieDatabase
{
    public class TheMovieDB : IMovieService
    {
        private IHttpClient _client;
        private string _apiKey;
        private string _baseUrl;        // "https://api.themoviedb.org";
        //private string _searchMovieUrl; // "3/search/movie";
        //private string _getMovieUrl;    // "3/movie";

        public TheMovieDB(IHttpClient client)
        {
            _client = client;
        }

        public TheMovieDB(IHttpClient client, string apiKey, string baseUrl)
        {
            _client = client;
            _apiKey = apiKey;
            _baseUrl = baseUrl;
        }

        public async Task<T> QueryAsync<T>(InternetMovieDBUrlBuilder uri)
        {
            string responseText = await _client.MakeRequest(await uri.ConstructUri());

            return JsonConvert.DeserializeObject<T>(responseText);
        }

        public async Task<T> QueryAsync<T>(string relativeUrl, Dictionary<String, String> queryPairs)
        {
            InternetMovieDBUrlBuilder uri = new InternetMovieDBUrlBuilder(_baseUrl + "/" + relativeUrl);
            uri.Add("api_key", _apiKey);
            foreach (var pair in queryPairs)
            {
                uri.Add(pair.Key, pair.Value);
            }

            return await QueryAsync<T>(uri);
        }
    }
}
