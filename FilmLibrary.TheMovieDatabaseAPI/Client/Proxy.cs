using System;
using System.Net;

namespace FilmLibrary.TheMovieDatabaseAPI.Client
{
    public class Proxy : IWebProxy
    {
        private ProxyConfig _proxyConfig;

        public Proxy(ProxyConfig proxyConfig)
        {
            _proxyConfig = proxyConfig;
            Credentials = new NetworkCredential(_proxyConfig.Username, _proxyConfig.Password);
        }

        public Uri GetProxy(Uri destination)
        {
            return new Uri(_proxyConfig.ProxyUrl);
        }

        public bool IsBypassed(Uri host)
        {
            return false;
        }

        public ICredentials Credentials { get; set; }
    }
}
