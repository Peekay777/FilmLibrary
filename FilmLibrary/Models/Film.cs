namespace FilmLibrary.Models
{
    public class Film
    {
        public int Id { get; set; }
        public int Tmdb_Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public ushort Runtime { get; set; }
        public string ReleaseDate { get; set; }
        public float VoteAverage { get; set; }
        public string Genre { get; set; }
        public string Backdrop_Filepath { get; set; }




        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Film film = (Film)obj;
            return 
                (Id == film.Id) && 
                (Title == film.Title) &&
                (Runtime == film.Runtime);
        }

        public override int GetHashCode()
        {
            return 
                Id.GetHashCode() ^ 
                (Title == null ? 0 : Title.GetHashCode()) ^ 
                Runtime.GetHashCode();
        }
    }
}