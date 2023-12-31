using AutoMapper;
using GeoCloudAI.Application.Dtos;
using GeoCloudAI.Application.Contracts;
using GeoCloudAI.Persistence.Contracts;

namespace GeoCloudAI.Application.Services
{
    public class CountryService: ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        private readonly IMapper _mapper;
        
        public CountryService(ICountryRepository countryRepository,
                              IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<List<CountryDto>> Get(string term) 
        {
            try
            {
                var countries = await _countryRepository.Get(term);
                if (countries == null) return null;
                //Map Class > Dto
                var result = _mapper.Map<List<CountryDto>>(countries);
                return result;         
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }

        public async Task<CountryDto> GetById(int countryId) 
        {
            try
            {
                var country = await _countryRepository.GetById(countryId);
                if (country == null) return null;
                //Map Class > Dto
                var result = _mapper.Map<CountryDto>(country);
                return result;         
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }  
        }
    }
}