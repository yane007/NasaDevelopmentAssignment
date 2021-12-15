using NasaServices.Contracts.Helpers;
using System.Net.Http;
using System.Threading.Tasks;

namespace NasaServices.Helpers
{
    public class HttpNasaClientService : IHttpNasaClientService
    {
        private readonly HttpClient _httpClient;

        public HttpNasaClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> GetAsync(string uri)
            => await _httpClient.GetAsync(uri);
    }
}
