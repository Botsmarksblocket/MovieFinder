using System.Text.Json.Serialization;

namespace MovieFinder.Client.Models
{
    public class MovieDetail
    {
        public int Id { get; set; }
        [JsonPropertyName("backdrop_path")]
        public string BackdropPath { get; set; }
        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("tagline")]
        public string Tagline { get; set; }
        [JsonPropertyName("overview")]
        public string Description { get; set; }
        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }
        [JsonPropertyName("runtime")]
        public int Runtime { get;set; }
        [JsonPropertyName("budget")]
        public int Budget { get; set; }
        [JsonPropertyName("genres")]
        public List<Genre> Genres { get; set; }
        [JsonPropertyName("production_companies")]
        public List<ProductionCompany> ProductionCompanies { get; set; }
    }
}
