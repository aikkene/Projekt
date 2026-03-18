using System.Text.Json.Serialization;

namespace projekt.Models
{
    public class PogodaResponse
    {
        [JsonPropertyName("weather")]
        public Pogoda[] Weather { get; set; }

        [JsonPropertyName("main")]
        public Glowne Main { get; set; }
    }

    public class Pogoda
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class Glowne
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }
    }
}
