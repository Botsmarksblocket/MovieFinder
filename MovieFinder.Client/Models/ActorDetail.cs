using System.Text.Json.Serialization;

namespace MovieFinder.Client.Models
{
    public class ActorDetail
    {
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("biography")]
        public string Biography { get; set; }

        [JsonPropertyName("birthday")]
        public string Birthday { get; set; }

        [JsonPropertyName("place_of_birth")]
        public string PlaceOfBirth { get; set; }

        [JsonPropertyName("profile_path")]
        public string ProfilePicture { get; set; }

        [JsonPropertyName("gender")]
        public int Gender { get; set; }
        [JsonPropertyName("known_for_department")]
        public string Department { get; set; }
    }
}
