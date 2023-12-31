using GeoCloudAI.Domain.Classes;
using GeoCloudAI.Persistence.Models;

namespace GeoCloudAI.Persistence.Contracts
{
    public interface ICountryRepository
    {
        Task<List<Country>> Get(string term);
        Task<Country> GetById(int id);
    }
}