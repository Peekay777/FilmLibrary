using System.Threading.Tasks;

namespace FilmLibrary.InternetMovieDB
{
    public interface IMovieService<T1, T2>
    {
        Task<T1> MovieSearchAsync(string query);
        Task<T2> GetMovieAsync(string movieId);
    }
}