using GeoCloudAI.Application.Dtos;
using GeoCloudAI.Persistence.Models;

namespace GeoCloudAI.Application.Contracts
{
    public interface IUserService
    {
        Task<UserDto> Add(UserDto userDto);
        Task<UserDto> Update(UserDto userDto);
        Task<int>     Delete(int userId);

        Task<PageList<UserDto>> Get(PageParams pageParams);
        Task<UserDto> GetById(int userId);
    }
}