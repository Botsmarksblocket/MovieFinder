using MovieFinder.Client.Models.Movies;
using System.Text.Json.Serialization;

namespace MovieFinder.Client.Models.Shared
{
    public class SearchResult
    {
        [JsonPropertyName("results")]
        public List<Movie> Results { get; set; }
    }
}
