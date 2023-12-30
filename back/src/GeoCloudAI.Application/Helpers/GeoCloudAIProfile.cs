using AutoMapper;
using GeoCloudAI.Application.Dtos;
using GeoCloudAI.Domain.Classes;

namespace GeoCloudAI.Application.Helpers
{
    public class GeoCloudAIProfile : Profile
    {
        public GeoCloudAIProfile()
        {
            CreateMap<User,    UserDto   >().ReverseMap();
            CreateMap<Account, AccountDto>().ReverseMap();
        }
    }
}