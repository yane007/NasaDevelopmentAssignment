using NasaServices.MappingModelsApi.Shared;
using NasaServices.Models.Asteroids;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NasaServices.MappingModelsApi
{
    public class Asteroid
    {
        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("neo_reference_id")]
        public string NeoReferenceId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_limited")]
        public string NameLimited { get; set; }

        [JsonProperty("designation")]
        public string Designation { get; set; }

        [JsonProperty("nasa_jpl_url")]
        public string NasaJplUrl { get; set; }

        [JsonProperty("absolute_magnitude_h")]
        public double AbsoluteMagnitudeH { get; set; }

        [JsonProperty("estimated_diameter")]
        public EstimatedDiameter EstimatedDiameter { get; set; }

        [JsonProperty("is_potentially_hazardous_asteroid")]
        public bool IsPotentiallyHazardousAsteroid { get; set; }

        [JsonProperty("close_approach_data")]
        public List<CloseApproachData> CloseApproachData { get; set; }

        [JsonProperty("orbital_data")]
        public OrbitalData OrbitalData { get; set; }

        [JsonProperty("is_sentry_object")]
        public bool IsSentryObject { get; set; }
    }
}