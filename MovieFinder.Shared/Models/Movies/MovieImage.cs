using System.Text.Json.Serialization;

namespace MovieFinder.Shared.Models.Movies
{
    //Seperate class with no ties to any other movie classes
    public class MovieImage
    {
        public int Id { get; set; }

        [JsonPropertyName("posters")]
        public List<MovieImages> Posters { get; set; }
    }

    public class MovieImages
    {
        [JsonPropertyName("file_path")]
        public string FilePath { get; set; }
    }
}
