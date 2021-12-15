using Newtonsoft.Json;

namespace NasaServices.MappingModelsApi.Shared
{
    public class Links
    {
        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("prev")]
        public string Prev { get; set; }

        [JsonProperty("self")]
        public string Self { get; set; }
    }
}
