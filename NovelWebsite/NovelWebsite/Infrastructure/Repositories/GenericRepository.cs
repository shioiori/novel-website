using Microsoft.EntityFrameworkCore;
using NovelWebsite.Domain.Enums;
using NovelWebsite.Domain.Interfaces;
using NovelWebsite.Infrastructure.Contexts;
using System.Linq.Expressions;

namespace NovelWebsite.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        private DbSet<T> _table;

        public GenericRepository(AppDbContext dbContext) 
        { 
            _dbContext = dbContext;
            _table = _dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(object id)
        {
            return _table.Find(id);
        }

        public void Insert(T obj)
        {
            _table.Add(obj);
        }

        public void Update(T obj)
        {
            _table.Update(obj);
        }

        public void Delete(object id)
        {
            T obj = _table.Find(id);
            _table.Remove(obj);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public IEnumerable<T> Order(Expression<Func<T, bool>> sortType, SortOrder sortOrder)
        {
            _table = _dbContext.Set<T>();
            if (sortOrder == SortOrder.Descending)
            {
                return _table.OrderByDescending(sortType);
            }
            return _table.OrderBy(sortType);
        }
    }
}
