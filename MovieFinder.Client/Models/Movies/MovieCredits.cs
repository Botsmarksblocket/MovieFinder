using System.Text.Json.Serialization;

namespace MovieFinder.Client.Models
{
    public class MovieCredits
    {
        [JsonPropertyName("cast")]
        public List<MovieCreditItem> Cast { get; set; }
    }

    public class MovieCreditItem
    {
        public int Id { get; set; }

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }
        [JsonPropertyName("vote_average")]
        public double Rating { get; set; }
    }
}
