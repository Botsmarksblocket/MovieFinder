using System.Text.Json.Serialization;

namespace MovieFinder.Shared.Models.Movies
{
    public class AvailableLanguage
    {
        [JsonPropertyName("name")]
        public string Language { get; set; }
    }
}
