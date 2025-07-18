using System.Text.Json.Serialization;

namespace MovieFinder.Client.Models.Actors
{
    public class Actor
    {
        public int Id { get; set; }

        [JsonPropertyName("cast")]
        public List<Cast> MovieCast { get; set; }
    }
}
