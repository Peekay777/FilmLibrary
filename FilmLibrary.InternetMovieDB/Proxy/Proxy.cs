using System;
using System.Net;

namespace FilmLibrary.InternetMovieDB.Proxy
{
    public class Proxy : IWebProxy
    {
        private string _proxyUrl;

        public Proxy(string proxyUrl, string username, string password)
        {
            _proxyUrl = proxyUrl;
            Credentials = new NetworkCredential(username, password);
        }

        public Uri GetProxy(Uri destination)
        {
            return new Uri(_proxyUrl);
        }

        public bool IsBypassed(Uri host)
        {
            return false;
        }

        public ICredentials Credentials { get; set; }
    }
}
