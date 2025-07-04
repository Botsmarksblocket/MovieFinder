using System.Text.Json.Serialization;

namespace MovieFinder.Client.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("vote_average")]
        public double Rating { get; set; }

        [JsonPropertyName("overview")]
        public string Description { get; set; }
        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDateRaw { get; set; }

        [JsonIgnore]
        public string ReleaseDate =>
        DateTime.TryParse(ReleaseDateRaw, out var date) ? date.Year.ToString() : "Unknown";
    }
}
