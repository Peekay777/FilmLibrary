using System;
using System.Net;

namespace FilmLibrary.TheMovieDatabaseAPI
{
    public class Proxy : IWebProxy
    {
        private string _proxyUri;

        public Proxy(string proxyUri)
        {
            _proxyUri = proxyUri;
        }

        public Uri GetProxy(Uri destination)
        {
            return new Uri(_proxyUri);
        }

        public bool IsBypassed(Uri host)
        {
            return false;
        }

        public ICredentials Credentials { get; set; }
    }
}
