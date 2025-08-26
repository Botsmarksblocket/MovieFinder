using System.Text.Json.Serialization;

namespace MovieFinder.Shared.Models.Actors
{
    public class Cast
    {
        public int Id { get; set; }

        [JsonPropertyName("profile_path")]
        public string ProfilePicture { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("character")]
        public string Character { get; set; }
    }
}
