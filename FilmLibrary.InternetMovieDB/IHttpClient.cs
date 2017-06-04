using System;
using System.Threading.Tasks;

namespace FilmLibrary.InternetMovieDB
{
    public interface IHttpClient
    {
        Task<string> MakeRequest(Uri address);
    }
}