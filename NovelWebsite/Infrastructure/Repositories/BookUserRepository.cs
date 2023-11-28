using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Repositories.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Interfaces;
using NovelWebsite.Domain.Enums;

namespace NovelWebsite.Infrastructure.Repositories
{
    public class BookUserRepository : GenericRepository<BookUsers>, IBookUserRepository
    {
        public BookUserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<BookUsers> GetByInteractionType(InteractionType type)
        {
            return _table.Where(x => x.InteractionId == (int)type);
        } 
    }
}
