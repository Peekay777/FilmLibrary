using FilmLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmLibrary.Data
{
    public class FilmLibraryContext : DbContext
    {
        public DbSet<Film> Films { get; set; }

        public FilmLibraryContext(DbContextOptions<FilmLibraryContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
