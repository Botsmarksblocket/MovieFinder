using MovieFinder.Client.Pages;
using System.Text.Json.Serialization;

namespace MovieFinder.Client.Models.Actors
{
    public class ActorImages
    {
        [JsonPropertyName("profiles")]
        public List<ActorImage> Profiles { get; set; }
    }

    public class ActorImage
    {
        [JsonPropertyName("file_path")]
        public string FilePath { get; set; }
    }
}
