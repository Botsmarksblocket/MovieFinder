using System.Text.Json.Serialization;

namespace MovieFinder.Client.Models
{
    public class SearchResult
    {
        [JsonPropertyName("results")]
        public List<Movie> Results { get; set; }
    }
}
