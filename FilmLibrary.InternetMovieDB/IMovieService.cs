using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmLibrary.InternetMovieDB
{
    public interface IMovieService
    {
        Task<T> QueryAsync<T>(InternetMovieDBUrlBuilder uri);
        Task<T> QueryAsync<T>(string relativeUrl, Dictionary<String, String> queryPairs);
    }
}