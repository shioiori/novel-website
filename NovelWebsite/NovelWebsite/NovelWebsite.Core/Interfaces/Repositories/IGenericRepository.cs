using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using System.Linq.Expressions;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Delete(T obj);
        Task DeleteAsync(object id);
        IQueryable<T> Filter(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        Task<T> GetByExpressionAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(object id);
        Task<T> InsertAsync(T obj);
        IQueryable<T> Order(Expression<Func<T, dynamic>> expression, SortOrder sortOrder);
        Task SaveAsync();
        Task<T> UpdateAsync(T obj);
        Task<int> CountAsync(Expression<Func<T, bool>> expression);
    }
}
