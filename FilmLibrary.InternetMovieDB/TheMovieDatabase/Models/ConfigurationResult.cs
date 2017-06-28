using Newtonsoft.Json;

namespace FilmLibrary.InternetMovieDB.TheMovieDatabase.Models
{
    public class ConfigurationResult
    {
        [JsonProperty(PropertyName = "images")]
        public ImagesConfiguration Images { get; set; }
        [JsonProperty(PropertyName = "change_keys")]
        public string[] Change_keys { get; set; }
    }

    public class ImagesConfiguration
    {
        [JsonProperty(PropertyName = "base_url")]
        public string Base_url { get; set; }
        [JsonProperty(PropertyName = "secure_base_url")]
        public string Secure_base_url { get; set; }
        [JsonProperty(PropertyName = "backdrop_sizes")]
        public string[] Backdrop_sizes { get; set; }
        [JsonProperty(PropertyName = "logo_sizes")]
        public string[] Logo_sizes { get; set; }
        [JsonProperty(PropertyName = "poster_sizes")]
        public string[] Poster_sizes { get; set; }
        [JsonProperty(PropertyName = "profile_sizes")]
        public string[] Profile_sizes { get; set; }
        [JsonProperty(PropertyName = "still_sizes")]
        public string[] Still_sizes { get; set; }
    }
}
