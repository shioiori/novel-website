using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.Infrastructure.Repositories;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using System.Linq;
using System.Linq.Expressions;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class BookUserRepository : GenericRepository<Book_User>, IBookUserRepository
    {
        public BookUserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

    }
}
