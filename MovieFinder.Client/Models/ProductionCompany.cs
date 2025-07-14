using System.Text.Json.Serialization;

namespace MovieFinder.Client.Models
{
    public class ProductionCompany
    {
        public int Id { get; set; }
        [JsonPropertyName("logo_path")]
        public string LogoPath { get; set; }
        [JsonPropertyName("name")]

        public string Name { get; set; }
        [JsonPropertyName("origin_country")]
        public string OriginCountry { get; set; }
    }
}
