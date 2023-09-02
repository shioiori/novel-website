using System.Linq.Expressions;

namespace NovelWebsite.Domain.Interfaces
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
        IEnumerable<T> Order(Expression<Func<T, object>> sortType, bool orderBy);
    }
}
