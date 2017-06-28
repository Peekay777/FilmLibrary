using Newtonsoft.Json;

namespace FilmLibrary.InternetMovieDB.TheMovieDatabase.Models
{
    public class MovieResult
    {
        [JsonProperty(PropertyName = "adult")]
        public bool Adult { get; set; }
        [JsonProperty(PropertyName = "backdrop_path")]
        public string Backdrop_path { get; set; }
        [JsonProperty(PropertyName = "belongs_to_collection")]
        public object Belongs_to_collection { get; set; }
        [JsonProperty(PropertyName = "budget")]
        public int Budget { get; set; }
        [JsonProperty(PropertyName = "genres")]
        public Genre[] Genres { get; set; }
        [JsonProperty(PropertyName = "homepage")]
        public string Homepage { get; set; }
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "imdb_id")]
        public string Imdb_id { get; set; }
        [JsonProperty(PropertyName = "original_language")]
        public string Original_language { get; set; }
        [JsonProperty(PropertyName = "original_title")]
        public string Original_title { get; set; }
        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }
        [JsonProperty(PropertyName = "popularity")]
        public float Popularity { get; set; }
        [JsonProperty(PropertyName = "poster_path")]
        public string Poster_path { get; set; }
        [JsonProperty(PropertyName = "production_companies")]
        public Production_Companies[] Production_companies { get; set; }
        [JsonProperty(PropertyName = "production_countries")]
        public Production_Countries[] Production_countries { get; set; }
        [JsonProperty(PropertyName = "release_date")]
        public string Release_date { get; set; }
        [JsonProperty(PropertyName = "revenue")]
        public int Revenue { get; set; }
        [JsonProperty(PropertyName = "runtime")]
        public int Runtime { get; set; }
        [JsonProperty(PropertyName = "spoken_languages")]
        public Spoken_Languages[] Spoken_languages { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "tagline")]
        public string Tagline { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "video")]
        public bool Video { get; set; }
        [JsonProperty(PropertyName = "vote_average")]
        public float Vote_average { get; set; }
        [JsonProperty(PropertyName = "vote_count")]
        public int Vote_count { get; set; }
        [JsonProperty(PropertyName = "images")]
        public Images Images { get; set; }
    }

    public class Images
    {
        [JsonProperty(PropertyName = "backdrops")]
        public Backdrop[] Backdrops { get; set; }
        [JsonProperty(PropertyName = "posters")]
        public object[] Posters { get; set; }
    }

    public class Backdrop
    {
        [JsonProperty(PropertyName = "aspect_ratio")]
        public float Aspect_ratio { get; set; }
        [JsonProperty(PropertyName = "file_path")]
        public string File_path { get; set; }
        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }
        [JsonProperty(PropertyName = "iso_639_1")]
        public string Iso_639_1 { get; set; }
        [JsonProperty(PropertyName = "vote_average")]
        public float Vote_average { get; set; }
        [JsonProperty(PropertyName = "vote_count")]
        public int Vote_count { get; set; }
        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }
    }

    public class Genre
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    public class Production_Companies
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }

    public class Production_Countries
    {
        [JsonProperty(PropertyName = "iso_3166_1")]
        public string Iso_3166_1 { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    public class Spoken_Languages
    {
        [JsonProperty(PropertyName = "iso_639_1")]
        public string Iso_639_1 { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
