using MovieFinder.Client.Models.Actors;
using MovieFinder.Client.Models.Shared;
using System.Text.Json.Serialization;

namespace MovieFinder.Client.Models.Movies
{
    //Contains more properties than the Movie-class. This class is used for the MoviePage
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

        [JsonPropertyName("runtime")]
        public int Runtime { get;set; }

        [JsonPropertyName("revenue")]
        public int Revenue { get; set; }

        [JsonPropertyName("vote_average")]
        public double Rating { get; set; }

        [JsonPropertyName("budget")]
        public int Budget { get; set; }

        [JsonPropertyName("spoken_languages")]
        public List<AvailableLanguage> Languages { get; set; }


        [JsonPropertyName("genres")]
        public List<Genre> Genres { get; set; }


        [JsonPropertyName("production_companies")]
        public List<ProductionCompany> ProductionCompanies { get; set; }

        [JsonPropertyName("movie_credits")]
        public MovieCredits MovieCredits { get; set; }

        [JsonPropertyName("images")]
        public ActorImages Images { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDateRaw { get; set; }

        [JsonIgnore]
        public string ReleaseDate =>
        DateTime.TryParse(ReleaseDateRaw, out var date) ? date.Year.ToString() : "Unknown";
    }
}
