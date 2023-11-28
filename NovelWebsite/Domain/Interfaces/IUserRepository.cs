using System.Linq.Expressions;
using Domain.Interfaces.Base;
using NovelWebsite.Domain.Entities;

namespace NovelWebsite.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
