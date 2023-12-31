using GeoCloudAI.Domain.Classes;
using GeoCloudAI.Persistence.Models;

namespace GeoCloudAI.Persistence.Contracts
{
    public interface IProfileRepository
    {
        Task<int> Add(Profile profile);
        Task<int> Update(Profile profile);
        Task<int> Delete(int id);

        Task<PageList<Profile>> Get(PageParams pageParams);
        Task<Profile> GetById(int id);
    }
}