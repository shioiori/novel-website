using Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Domain.Enums;
using NovelWebsite.Infrastructure.Contexts;
using System.Linq.Expressions;

namespace NovelWebsite.Infrastructure.Repositories.Base
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

        public async Task<T> InsertAsync(T obj)
        {
            return (await _table.AddAsync(obj)).Entity;
        }

        public async Task<T> UpdateAsync(T obj)
        {
            _dbContext.Entry(obj).CurrentValues.SetValues(obj);
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task DeleteAsync(object id)
        {
            T obj = await _table.FindAsync(id);
            _table.Remove(obj);
        }

        public void Delete(T obj)
        {
            _table.Remove(obj);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> exp = null)
        {
            if (exp == null)
            {
                return _table.AsQueryable();
            }
            return _table.Where(exp);
        }
    }
}
