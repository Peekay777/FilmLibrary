using System;
using System.Net;
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
            HttpResponseMessage response = await _httpClient.GetAsync(address);

            switch (response.StatusCode)
            {
                // 200
                case HttpStatusCode.OK:
                    return await response.Content.ReadAsStringAsync();
                // 401
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedException();
                // 404
                case HttpStatusCode.NotFound:
                    throw new NotFoundException();
                default:
                    throw new Exception();
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
