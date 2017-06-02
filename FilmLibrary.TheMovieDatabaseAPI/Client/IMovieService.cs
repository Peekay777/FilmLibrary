using System.Threading.Tasks;

namespace FilmLibrary.TheMovieDatabaseAPI.Client
{
    public interface IMovieService
    {
        Task<string> MovieSearch(string apiKey, string query);
        Task<string> GetMovie(string apiKey, int movieId);
    }
}