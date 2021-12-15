using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace NasaServices.MappingModelsApi
{
    public class AstronomyPictureOfTheDay
    {

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("date")]
        [DisplayName("Search date: ")]
        public DateTime Date { get; set; }

        [JsonProperty("explanation")]
        public string Explanation { get; set; }

        [JsonProperty("hdurl")]
        public string Hdurl { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("service_version")]
        public string ServiceVersion { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
