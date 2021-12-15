using Newtonsoft.Json;

namespace NasaServices.Models.Asteroids
{
    public class Miles
    {
        [JsonProperty("estimated_diameter_min")]
        public double EstimatedDiameterMin { get; set; }

        [JsonProperty("estimated_diameter_max")]
        public double EstimatedDiameterMax { get; set; }
    }
}
