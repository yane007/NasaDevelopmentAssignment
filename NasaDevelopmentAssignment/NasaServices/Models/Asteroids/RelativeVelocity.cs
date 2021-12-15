using Newtonsoft.Json;

namespace NasaServices.Models.Asteroids
{
    public class RelativeVelocity
    {
        [JsonProperty("kilometers_per_second")]
        public string KilometersPerSecond { get; set; }

        [JsonProperty("kilometers_per_hour")]
        public string KilometersPerHour { get; set; }

        [JsonProperty("miles_per_hour")]
        public string MilesPerHour { get; set; }
    }
}
