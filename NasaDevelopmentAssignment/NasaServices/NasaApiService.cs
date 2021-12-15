using NasaServices.Contracts;
using NasaServices.Contracts.Helpers;
using NasaServices.MappingModelsApi;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace NasaServices
{
    public class NasaApiService : INasaApiService
    {
        private readonly IHttpNasaClientService _httpNasaClientService;

        public NasaApiService(IHttpNasaClientService httpNasaClientService)
        {
            this._httpNasaClientService = httpNasaClientService;
        }


        public async Task<NeoBrowse> GetAsteroids(string date = "")
        {
            string requestUrl = "neo/rest/v1/neo/browse/?api_key=65Pf0ZrbQreMeiseMtjN3QI64QfBSneSmQPeBt53";

            if (!string.IsNullOrEmpty(date))
            {
                requestUrl += $"&page={date}";
            }

            var response = await _httpNasaClientService.GetAsync(requestUrl);

            string jsonResult = await response.Content.ReadAsStringAsync();

            var asteroids = JsonConvert.DeserializeObject<NeoBrowse>(jsonResult);

            return asteroids;
        }

        public async Task<AstronomyPictureOfTheDay> GetAPOD(string date)
        {
            string requestUrl = "planetary/apod?api_key=65Pf0ZrbQreMeiseMtjN3QI64QfBSneSmQPeBt53";

            if (!string.IsNullOrEmpty(date))
            {
                var newDate = DateTime.Parse(date).ToString("yyyy'-'MM'-'dd");

                requestUrl += $"&date={newDate}";
            }

            var response = await _httpNasaClientService.GetAsync(requestUrl);

            string jsonResult = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AstronomyPictureOfTheDay>(jsonResult);
        }
    }
}


