using System.Linq.Expressions;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Services
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T Add(T obj);
        T Update(T obj);
        void Delete(T obj);
    }
}
