using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FilmLibrary.InternetMovieDB.TheMovieDatabase
{
    public class TheMovieDBHttpClient : IHttpClient
    {
        private static HttpClient _httpClient;

        public TheMovieDBHttpClient()
        {
            var httpClientHandler = new HttpClientHandler
            {
                UseProxy = false
            };
            SetJsonHttpClient(httpClientHandler);
        }

        public TheMovieDBHttpClient(string proxyUrl, string username, string password)
        {
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = new Proxy.Proxy(proxyUrl, username, password)
            };
            SetJsonHttpClient(httpClientHandler);
        }

        public async Task<string> MakeRequest(Uri address)
        {
            try
            {
                return await _httpClient.GetStringAsync(address);
            }
            catch
            {
                return "";
            }
        }

        private void SetJsonHttpClient(HttpClientHandler handler)
        {
            _httpClient = new HttpClient(handler);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
