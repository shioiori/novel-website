using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Repositories.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Interfaces;

namespace NovelWebsite.Infrastructure.Repositories
{
    public class BookTagRepository : GenericRepository<BookTags>, IBookTagRepository
    {
        public BookTagRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
