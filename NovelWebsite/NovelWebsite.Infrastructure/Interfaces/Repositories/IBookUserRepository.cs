using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Repositories
{
    public interface IBookUserRepository : IGenericRepository<Book_User>
    {
        IEnumerable<Book_User> GetByInteractionType(InteractionType type);
    }
}
