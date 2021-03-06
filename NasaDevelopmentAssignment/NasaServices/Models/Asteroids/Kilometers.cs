using Newtonsoft.Json;

namespace NasaServices.Models.Asteroids
{
    public class Kilometers
    {

        [JsonProperty("estimated_diameter_min")]
        public double EstimatedDiameterMin { get; set; }

        [JsonProperty("estimated_diameter_max")]
        public double EstimatedDiameterMax { get; set; }
    }
}
