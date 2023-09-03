using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces;

namespace NovelWebsite.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository) {
            _bookRepository = bookRepository;
        }

        public IEnumerable<BookEntity> GetBookByAuthor(int authorId)
        {
            return _bookRepository.Filter(x => x.AuthorId == authorId);
        }
    }
}
