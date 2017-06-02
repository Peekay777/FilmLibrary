using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FilmLibrary.TheMovieDatabaseAPI.Client
{
    public class TmdbHttpClient : IMovieService
    {
        private static HttpClient _httpClient;
        private const string _baseUrl = "https://api.themoviedb.org";
        private const string _searchMovieUrl = "3/search/movie";
        private const string _getMovieUrl = "3/movie";

        /// <summary>
        /// Constructor for TmdbHttpClient with no proxy
        /// </summary>
        public TmdbHttpClient()
        {
            var httpClientHandler = new HttpClientHandler
            {
                UseProxy = false
            };
            SetJsonHttpClient(httpClientHandler);
        }

        /// <summary>
        /// Constructor for TmdbHttpClient with proxy
        /// </summary>
        public TmdbHttpClient(ProxyConfig proxyConfig)
        {
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = new Proxy(proxyConfig)
            };
            SetJsonHttpClient(httpClientHandler);
        }
        

        /// <summary>
        /// Configure the Http Handler for JSON requests
        /// </summary>
        /// <param name="handler"></param>
        private void SetJsonHttpClient(HttpClientHandler handler)
        {
            _httpClient = new HttpClient(handler);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Build a movie search url
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="query"></param>
        /// <param name="baseUrl"></param>
        /// <param name="relativeUrl"></param>
        /// <returns></returns>
        private async Task<string> GetMovieSearchAddress(string apiKey, string query, string baseUrl, string relativeUrl)
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

        private async Task<string> GetMovieAddress(string apiKey, int movieId, string baseUrl, string relativeUrl)
        {
            Uri baseUri = new Uri(baseUrl);
            Uri getMovieUrl = new Uri(baseUri, relativeUrl + "/" + movieId.ToString());
            var url = new UriBuilder(getMovieUrl);

            using (var content = new FormUrlEncodedContent(
                new KeyValuePair<string, string>[]{
                    new KeyValuePair<string, string>("api_key", apiKey),
                    new KeyValuePair<string, string>("language", "en-US")
            }))
            {
                url.Query = await content.ReadAsStringAsync();
            }

            return url.Uri.AbsoluteUri;
        }

        /// <summary>
        /// Search for a movie
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<string> MovieSearch(string apiKey, string query)
        {
            try
            {
                string address = await GetMovieSearchAddress(apiKey, query, _baseUrl, _searchMovieUrl);
                return await _httpClient.GetStringAsync(address);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> GetMovie(string apiKey, int movieId)
        {
            try
            {
                string address = await GetMovieAddress(apiKey, movieId, _baseUrl, _getMovieUrl);
                return await _httpClient.GetStringAsync(address);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
