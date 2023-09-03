using NovelWebsite.Infrastructure.Entities;

namespace NovelWebsite.NovelWebsite.Core.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookEntity> GetBookByAuthor(int authorId);

    }
}
