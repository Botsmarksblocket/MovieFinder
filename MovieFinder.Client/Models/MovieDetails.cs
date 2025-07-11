using System.Text.Json.Serialization;

namespace MovieFinder.Client.Models
{
    public class MovieDetails
    {
        public int Id { get; set; }
        [JsonPropertyName("backdrop_path")]
        public string BackdropPath { get; set; }
        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }

    }
}
