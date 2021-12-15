using NasaServices.MappingModelsApi.Shared;
using NasaServices.Models.Shared;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NasaServices.MappingModelsApi
{
    public class NeoBrowse
    {
        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("page")]
        public Page Page { get; set; }

        [JsonProperty("near_earth_objects")]
        public IList<Asteroid> Asteroids { get; set; }
    }




}
