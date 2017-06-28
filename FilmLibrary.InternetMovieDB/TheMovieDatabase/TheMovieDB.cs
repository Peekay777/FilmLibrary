using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmLibrary.InternetMovieDB.TheMovieDatabase
{
    public class TheMovieDB : IMovieService
    {
        private IHttpClient _client;
        private string _apiKey;
        private string _baseUrl;        // "https://api.themoviedb.org";

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

        public async Task<T> QueryAsync<T>(string relativeUrl = "", Dictionary<string, string> queryPairs = null)
        {
            if (!string.IsNullOrEmpty(relativeUrl))
            {
                relativeUrl = "/" + relativeUrl;
            }

            InternetMovieDBUrlBuilder uri = new InternetMovieDBUrlBuilder(_baseUrl + relativeUrl);
            uri.Add("api_key", _apiKey);

            if (queryPairs != null)
            {
                foreach (var pair in queryPairs)
                {
                    uri.Add(pair.Key, pair.Value);
                }
            }

            return await QueryAsync<T>(uri);
        }
    }
}
