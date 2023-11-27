using IdentityModel;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using System.Linq.Expressions;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
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

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable<T>();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<T> GetByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return await _table.FirstOrDefaultAsync(expression);
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

        public IQueryable<T> Order(Expression<Func<T, dynamic>> expression, SortOrder sortOrder)
        {
            _table = _dbContext.Set<T>();
            if (sortOrder == SortOrder.Descending)
            {
                return _table.OrderByDescending(expression);
            }
            return _table.OrderBy(expression);
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> expression)
        {
            _table = _dbContext.Set<T>();
            return _table.Where(expression);
        }
        
        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            _table = _dbContext.Set<T>();
            return await _table.CountAsync(expression);
        }
    }
}
