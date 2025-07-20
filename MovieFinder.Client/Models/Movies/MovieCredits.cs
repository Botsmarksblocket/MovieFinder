using System.Text.Json.Serialization;

namespace MovieFinder.Client.Models.Movies
{
    public class MovieCredits
    {
        [JsonPropertyName("cast")]
        public List<Movie> Cast { get; set; }
    }
}
