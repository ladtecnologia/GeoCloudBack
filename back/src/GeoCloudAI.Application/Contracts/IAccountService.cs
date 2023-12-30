using GeoCloudAI.Application.Dtos;
using GeoCloudAI.Persistence.Models;

namespace GeoCloudAI.Application.Contracts
{
    public interface IAccountService
    {
        Task<AccountDto> Add(AccountDto accountDto);
        Task<AccountDto> Update(AccountDto accountDto);
        Task<int>     Delete(int accountId);

        Task<PageList<AccountDto>> Get(PageParams pageParams);
        Task<AccountDto> GetById(int accountId);
    }
}