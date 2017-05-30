namespace FilmLibrary.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ushort RunningTimeInMinutes { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Film film = (Film)obj;
            return 
                (Id == film.Id) && 
                (Name == film.Name) &&
                (RunningTimeInMinutes == film.RunningTimeInMinutes);
        }

        public override int GetHashCode()
        {
            return 
                Id.GetHashCode() ^ 
                (Name == null ? 0 : Name.GetHashCode()) ^ 
                RunningTimeInMinutes.GetHashCode();
        }
    }
}