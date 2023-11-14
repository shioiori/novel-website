using NovelWebsite.NovelWebsite.Core.Enums;
using System.Linq.Expressions;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Repositories
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        T GetByExpression(Expression<Func<T, bool>> expression);
        T Insert(T obj);
        T Update(T obj);
        void Delete(object id);
        void Delete(T obj);
        void Save();
        IEnumerable<T> Order(Expression<Func<T, dynamic>> expression, SortOrder sortOrder);
        IEnumerable<T> Filter(Expression<Func<T, bool>> expression);
        IEnumerable<T> ContainName(Expression<Func<T, bool>> expression);
    }
}
