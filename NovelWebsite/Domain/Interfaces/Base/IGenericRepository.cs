using NovelWebsite.Domain.Enums;
using System.Linq.Expressions;

namespace Domain.Interfaces.Base
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Get(Expression<Func<T, bool>> exp = null);
        Task<T> InsertAsync(T obj);
        Task<T> UpdateAsync(T obj);
        void Delete(T obj);
        Task DeleteAsync(object id);
        Task SaveAsync();
    }
}
