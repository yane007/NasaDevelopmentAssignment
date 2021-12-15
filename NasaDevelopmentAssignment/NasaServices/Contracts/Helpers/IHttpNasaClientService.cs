using System.Net.Http;
using System.Threading.Tasks;

namespace NasaServices.Contracts.Helpers
{
    public interface IHttpNasaClientService
    {
        Task<HttpResponseMessage> GetAsync(string url);
    }
}
