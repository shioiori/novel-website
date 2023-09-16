using System.Linq.Expressions;
using NovelWebsite.Infrastructure.Entities;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Repositories
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Account IfExistsAccount(Expression<Func<Account, bool>> expression);
        Account GetAccountByEmail(string email);
        Account GetAccountByUsername(string username);
    }
}
