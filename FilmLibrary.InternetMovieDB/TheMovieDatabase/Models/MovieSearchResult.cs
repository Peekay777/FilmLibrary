using Newtonsoft.Json;

namespace FilmLibrary.InternetMovieDB.TheMovieDatabase.Models
{
    public class MovieSearchResult
    {
        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }
        [JsonProperty(PropertyName = "results")]
        public Result[] Results { get; set; }
        [JsonProperty(PropertyName = "total_results")]
        public int Total_results { get; set; }
        [JsonProperty(PropertyName = "total_pages")]
        public int Total_pages { get; set; }
    }

    public class Result
    {
        [JsonProperty(PropertyName = "poster_path")]
        public string Poster_path { get; set; }
        [JsonProperty(PropertyName = "adult")]
        public bool Adult { get; set; }
        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }
        [JsonProperty(PropertyName = "release_date")]
        public string Release_date { get; set; }
        [JsonProperty(PropertyName = "genre_ids")]
        public int?[] Genre_ids { get; set; }
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "original_title")]
        public string Original_title { get; set; }
        [JsonProperty(PropertyName = "original_language")]
        public string Original_language { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "backdrop_path")]
        public string Backdrop_path { get; set; }
        [JsonProperty(PropertyName = "popularity")]
        public float Popularity { get; set; }
        [JsonProperty(PropertyName = "vote_count")]
        public int Vote_count { get; set; }
        [JsonProperty(PropertyName = "video")]
        public bool Video { get; set; }
        [JsonProperty(PropertyName = "vote_average")]
        public float Vote_average { get; set; }
    }
}
