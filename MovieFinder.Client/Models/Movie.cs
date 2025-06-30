using System.Text.Json.Serialization;

namespace MovieFinder.Client.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Overview { get; set; }
        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }
    }
}
