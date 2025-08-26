using MovieFinder.Shared.Models.Movies;
using System.Text.Json.Serialization;

namespace MovieFinder.Shared.Models.Common
{
    public class SearchResult
    {
        [JsonPropertyName("results")]
        public List<Movie> Results { get; set; }
    }
}
