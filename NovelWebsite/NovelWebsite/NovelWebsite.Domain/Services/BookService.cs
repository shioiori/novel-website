using AutoMapper;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Models;
using System.Linq.Expressions;
using static System.Reflection.Metadata.BlobBuilder;

namespace NovelWebsite.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        Expression<Func<Book, bool>> expValidBooks = b => b.Status == 0 && b.IsDeleted == false;
        Expression<Func<Book, bool>> expFilterByCategory(int categoryId)
        {
            return x => x.CategoryId == categoryId;
        }
        Expression<Func<Book, bool>> expFilterByAuthor(int authorId)
        {
            return x => x.AuthorId == authorId;
        }
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public IEnumerable<BookModel> GetValidBooks()
        {
            var books = _bookRepository.GetAll();
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
        }

        public IEnumerable<BookModel> GetValidBooksByAuthor(int authorId)
        {
            var books = _bookRepository.Filter(expValidBooks).Where(expFilterByAuthor(authorId).Compile());
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books); 
        }

        public IEnumerable<BookModel> GetValidBooksByCategory(int categoryId)
        {
            var books = _bookRepository.Filter(expValidBooks).Where(expFilterByCategory(categoryId).Compile());
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
        }

    }
}
