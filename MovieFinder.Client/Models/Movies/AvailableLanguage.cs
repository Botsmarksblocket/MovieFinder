using System.Text.Json.Serialization;

namespace MovieFinder.Client.Models.Movies
{
    public class AvailableLanguage
    {
        [JsonPropertyName("name")]
        public string Language { get; set; }
    }
}
