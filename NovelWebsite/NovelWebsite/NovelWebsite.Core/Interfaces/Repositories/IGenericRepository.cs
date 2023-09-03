using NovelWebsite.NovelWebsite.Core.Enums;
using System.Linq.Expressions;

namespace NovelWebsite.NovelWebsite.Core.Interfaces
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
        IEnumerable<T> Order(Expression<Func<T, dynamic>> expression, SortOrder sortOrder);
        IEnumerable<T> Filter(Expression<Func<T, bool>> expression);
        IEnumerable<T> ContainName(Expression<Func<T, bool>> expression);
    }
}
