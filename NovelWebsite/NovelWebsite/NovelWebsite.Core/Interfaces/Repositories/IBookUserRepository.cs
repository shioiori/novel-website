using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Repositories
{
    public interface IBookUserRepository : IGenericRepository<BookUsers>
    {
        IEnumerable<BookUsers> GetByInteractionType(InteractionType type);
    }
}
