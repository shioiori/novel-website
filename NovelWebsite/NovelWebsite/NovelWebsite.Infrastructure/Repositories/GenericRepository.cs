using Microsoft.EntityFrameworkCore;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using System.Linq.Expressions;

namespace NovelWebsite.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext;
        protected DbSet<T> _table;

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

        public T GetByExpression(Expression<Func<T, bool>> expression)
        {
            return _table.FirstOrDefault(expression);
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

        public IEnumerable<T> Order(Expression<Func<T, dynamic>> expression, SortOrder sortOrder)
        {
            _table = _dbContext.Set<T>();
            if (sortOrder == SortOrder.Descending)
            {
                return _table.OrderByDescending(expression);
            }
            return _table.OrderBy(expression);
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> expression)
        {
            _table = _dbContext.Set<T>();
            return _table.Where(expression);
        }

        public IEnumerable<T> ContainName(Expression<Func<T, bool>> expression)
        {
            _table = _dbContext.Set<T>();
            return _table.Where(expression);
        }
    }
}
