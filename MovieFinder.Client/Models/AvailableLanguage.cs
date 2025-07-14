using System.Text.Json.Serialization;

namespace MovieFinder.Client.Models
{
    public class AvailableLanguage
    {
        [JsonPropertyName("name")]
        public string Language { get; set; }
    }
}
