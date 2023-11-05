using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class BookTagRepository : GenericRepository<Book_Tag>, IBookTagRepository
    {
        public BookTagRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
