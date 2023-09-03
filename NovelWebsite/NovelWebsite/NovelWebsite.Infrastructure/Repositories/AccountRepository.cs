using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.Infrastructure.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class AccountRepository : GenericRepository<AccountEntity>, IAccountRepository
    {
        public AccountRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public AccountEntity GetAccount(string username, string password){
            return _table.FirstOrDefault(t => t.AccountName == username && t.Password == password);
        }
    }
}
