using System.Text.Json.Serialization;

namespace MovieFinder.Client.Models
{
    public class SearchResult
    {
        public int Page { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }

        [JsonPropertyName("results")]
        public List<Movie> Results { get; set; }
    }
}
