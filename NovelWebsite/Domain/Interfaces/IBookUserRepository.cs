using Domain.Interfaces.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Enums;

namespace NovelWebsite.Domain.Interfaces
{
    public interface IBookUserRepository : IGenericRepository<BookUsers>
    {
        IQueryable<BookUsers> GetByInteractionType(InteractionType type);
    }
}
