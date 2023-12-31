using GeoCloudAI.Application.Dtos;
using GeoCloudAI.Persistence.Models;

namespace GeoCloudAI.Application.Contracts
{
    public interface IProfileService
    {
        Task<ProfileDto> Add(ProfileDto profileDto);
        Task<ProfileDto> Update(ProfileDto profileDto);
        Task<int>        Delete(int profileId);

        Task<PageList<ProfileDto>> Get(PageParams pageParams);
        Task<ProfileDto> GetById(int profileId);
    }
}