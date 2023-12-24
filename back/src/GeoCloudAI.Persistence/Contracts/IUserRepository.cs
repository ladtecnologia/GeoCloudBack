using GeoCloudAI.Domain.Classes;
using GeoCloudAI.Persistence.Models;

namespace GeoCloudAI.Persistence.Contracts
{
    public interface IUserRepository
    {
        Task<int> Add(User user);
        Task<int> Update(User user);
        Task<int> Delete(int id);

        Task<PageList<User>> Get(PageParams pageParams);
        Task<User> GetById(int id); 
    }
}