using GeoCloudAI.Application.Dtos;

namespace GeoCloudAI.Application.Contracts
{
    public interface ICountryService
    {
        Task<List<CountryDto>> Get(string term);
        Task<CountryDto> GetById(int countryId);
    }
}