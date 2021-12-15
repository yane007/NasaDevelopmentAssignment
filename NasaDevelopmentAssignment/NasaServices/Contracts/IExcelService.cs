using NasaServices.MappingModelsApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NasaServices.Contracts
{
    public interface IExcelService
    {
        Task<byte[]> CreateNasaFile(NeoBrowse apod);
    }
}
