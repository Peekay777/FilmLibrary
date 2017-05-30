using FilmLibrary.TheMovieDatabaseAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FilmLibrary.TheMovieDatabaseAPI
{
    public class TheMovieDbApi
    {
        private static string _apiKey;
        private static HttpClient _httpJsonClient;
        private const string _baseUrl = "https://api.themoviedb.org";
        private const string _searchMovieUrl = "3/search/movie";


        public TheMovieDbApi(string apiKey)
        {
            _apiKey = apiKey;
            SetupHttpJsonClient();
        }

        public TheMovieDbApi(string apiKey, string proxyUrl, string username, string password)
        {
            _apiKey = apiKey;
            SetupHttpJsonClient(proxyUrl, username, password);
        }

        public async Task<MovieResults> FindMovie(string query)
        {
            string address = await GetMovieSearchAddress(query, _baseUrl, _searchMovieUrl, _apiKey);
            string reponseText = await GetResponseText(address);
            return JsonConvert.DeserializeObject<MovieResults>(reponseText);
        }

        private static async Task<string> GetMovieSearchAddress(string query, string baseUrl, string relativeUrl, string apiKey)
        {
            Uri baseUri = new Uri(baseUrl);
            Uri searchMovieUrl = new Uri(baseUri, relativeUrl);
            var url = new UriBuilder(searchMovieUrl);

            using (var content = new FormUrlEncodedContent(
                new KeyValuePair<string, string>[]{
                    new KeyValuePair<string, string>("api_key", apiKey),
                    new KeyValuePair<string, string>("language", "en-US"),
                    new KeyValuePair<string, string>("page", "1"),
                    new KeyValuePair<string, string>("include_adult", "false"),
                    new KeyValuePair<string, string>("query", query),
            }))
            {
                url.Query = await content.ReadAsStringAsync();
            }

            return url.Uri.AbsoluteUri;
        }

        private void SetupHttpJsonClient()
        {
            var httpClientHandler = new HttpClientHandler
            {
                UseProxy = false
            };

            SetupHttpHandler(httpClientHandler);
        }

        private static void SetupHttpJsonClient(string proxyUrl, string username, string password)
        {
            var proxy = new Proxy(proxyUrl)
            {
                Credentials = new NetworkCredential(username, password)
            };

            var httpClientHandler = new HttpClientHandler
            {
                Proxy = proxy
            };

            SetupHttpHandler(httpClientHandler);
        }

        private static void SetupHttpHandler(HttpClientHandler httpClientHandler)
        {
            _httpJsonClient = new HttpClient(httpClientHandler);
            _httpJsonClient.DefaultRequestHeaders.Accept.Clear();
            _httpJsonClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<string> GetResponseText(string address)
        {
            try
            {
                return await _httpJsonClient.GetStringAsync(address);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
