using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Repositories
{
    public interface IBookUserRepository : IGenericRepository<BookUsers>
    {
        IQueryable<BookUsers> GetByInteractionType(InteractionType type);
    }
}
