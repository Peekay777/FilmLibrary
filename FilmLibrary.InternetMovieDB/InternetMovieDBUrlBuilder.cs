using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.InternetMovieDB
{
    public class InternetMovieDBUrlBuilder
    {
        private List<KeyValuePair<string, string>> _queryPairs;
        private string _baseurl;

        public InternetMovieDBUrlBuilder(string baseurl)
        {
            _queryPairs = new List<KeyValuePair<string, string>>();
            _baseurl = baseurl;
        }

        public void Add(string key, string value)
        {
            _queryPairs.Add(new KeyValuePair<string, string>(key, value));
        }

        public async Task<Uri> ConstructUri()
        {
            var url = new UriBuilder(_baseurl);
            
            using (var content = new FormUrlEncodedContent(_queryPairs.ToArray()))
            {
                url.Query = await content.ReadAsStringAsync();
            }

            return url.Uri;
        }
    }
}
