using NasaServices.MappingModelsApi;
using System.Threading.Tasks;

namespace NasaServices.Contracts
{
    public interface INasaApiService
    {
        Task<NeoBrowse> GetAsteroids(string date = "");

        Task<AstronomyPictureOfTheDay> GetAPOD(string date = "");
    }
}
