using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using System.Linq;
using System.Linq.Expressions;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class BookUserRepository : GenericRepository<BookUsers>, IBookUserRepository
    {
        public BookUserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<BookUsers> GetByInteractionType(InteractionType type)
        {
            return _table.Where(x => x.InteractionId == (int)type);
        } 
    }
}
