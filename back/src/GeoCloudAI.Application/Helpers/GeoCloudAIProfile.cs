using GeoCloudAI.Application.Dtos;
using GeoCloudAI.Domain.Classes;

namespace GeoCloudAI.Application.Helpers
{
    public class GeoCloudAIProfile : AutoMapper.Profile
    {
        public GeoCloudAIProfile()
        {
            CreateMap<User,    UserDto   >().ReverseMap();
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<Profile, ProfileDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
        }
    }
}