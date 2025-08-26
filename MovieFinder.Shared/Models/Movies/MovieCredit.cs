using System.Text.Json.Serialization;

namespace MovieFinder.Shared.Models.Movies
{
    public class MovieCredit
    {
        [JsonPropertyName("cast")]
        public List<Movie> Cast { get; set; }
    }
}
