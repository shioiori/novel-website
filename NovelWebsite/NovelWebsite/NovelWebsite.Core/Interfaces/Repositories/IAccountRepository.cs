using NovelWebsite.Infrastructure.Entities;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Repositories
{
    public interface IAccountRepository : IGenericRepository<AccountEntity>
    {
        AccountEntity GetAccount(string username, string password);
    }
}
