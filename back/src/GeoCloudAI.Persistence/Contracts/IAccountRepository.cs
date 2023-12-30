using GeoCloudAI.Domain.Classes;
using GeoCloudAI.Persistence.Models;

namespace GeoCloudAI.Persistence.Contracts
{
    public interface IAccountRepository
    {
        Task<int> Add(Account account);
        Task<int> Update(Account account);
        Task<int> Delete(int id);

        Task<PageList<Account>> Get(PageParams pageParams);
        Task<Account> GetById(int id);
    }
}