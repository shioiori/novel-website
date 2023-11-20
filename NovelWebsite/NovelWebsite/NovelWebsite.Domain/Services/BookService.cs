using AutoMapper;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Constants;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Domain.Utils;
using System.Linq.Expressions;
using Google.Apis.Drive.v3.Data;

namespace NovelWebsite.Domain.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IChapterRepository _chapterRepository;
        private readonly IBookUserRepository _bookUserRepository;
        private readonly IBookTagRepository _bookTagRepository;
        private readonly IMapper _mapper;

        Expression<Func<Book, bool>> expValidBooks = b => b.IsDeleted == false && b.Status == (int)UploadStatus.Publish;
        Expression<Func<Book, bool>> expFilterByAuthor(int authorId)
        {
            return b => b.AuthorId == authorId;
        }
        Expression<Func<Book, bool>> expFilterByCategory(int categoryId)
        {
            return b => b.CategoryId == categoryId;
        }
        Expression<Func<Book, bool>> expFilterByUploadStatus(UploadStatus status)
        {
            return b => b.Status == (int)status;
        }
        Expression<Func<Book, bool>> expFilterByBookStatus(string status)
        {
            return b => b.BookStatus == status;
        }
        Expression<Func<Book, bool>> expFromTime(DateTime start)
        {
            return b => b.CreatedDate >= start;
        }
        Expression<Func<BookUsers, bool>> expFilterByInteractionType(InteractionType type)
        {
            return b => b.InteractionId == (int)type;
        }
        Expression<Func<Book, bool>> expSearchName(string name) {
            return x => string.IsNullOrEmpty(name)
                        || x.BookName.ToLower().Trim().Contains(name.ToLower().Trim());
        }

        public BookService(IBookRepository bookRepository, 
            IBookUserRepository bookUserRepository, 
            IChapterRepository chapterRepository,
            IBookTagRepository bookTagRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _bookUserRepository = bookUserRepository;
            _chapterRepository = chapterRepository;
            _bookTagRepository = bookTagRepository;
            _mapper = mapper;
        }

        public IEnumerable<BookModel> GetAll()
        {
            var books = _bookRepository.Filter(expValidBooks);
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
        }

        public IEnumerable<BookModel> GetByAuthor(int authorId)
        {
            var exp = ExpressionUtil<Book>.Combine(expValidBooks, expFilterByAuthor(authorId));
            var books = _bookRepository.Filter(exp);
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books); 
        }

        public IEnumerable<BookModel> GetByCategory(int categoryId)
        {
            var exp = ExpressionUtil<Book>.Combine(expValidBooks, expFilterByCategory(categoryId));
            var books = _bookRepository.Filter(exp);
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
        }

        public IEnumerable<BookModel> GetByBookStatus(string status)
        {
            var exp = ExpressionUtil<Book>.Combine(expValidBooks, expFilterByBookStatus(status));
            var books = _bookRepository.Filter(exp);
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
        }

        public IEnumerable<BookModel> GetFromTime(DateTime start)
        {
            var books = _bookRepository.Filter(expFromTime(start));
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
        }

        public IEnumerable<BookModel> GetByFilter(FilterModel filter)
        {
            var exp = expSearchName(filter.SearchName);
            // lọc theo tình trạng
            if (filter.BookStatuses != null)
            {
                var bookStatuses = filter.BookStatuses.ToArray();
                if (bookStatuses.Length > 0)
                {
                    var expBookStatuses = expFilterByBookStatus(bookStatuses[0]);
                    for (int i = 1; i < bookStatuses.Length; ++i)
                    {
                        expBookStatuses = ExpressionUtil<Book>.Or(expBookStatuses, expFilterByBookStatus(bookStatuses[i]));
                    }
                    exp = ExpressionUtil<Book>.Combine(exp, expBookStatuses);
                }
            }

            // lọc theo thể loại
            if (filter.CategoryIds != null)
            {
                var categories = filter.CategoryIds.ToArray();
                if (categories.Length > 0)
                {
                    var expCategories = expFilterByCategory(categories[0]);
                    for (int i = 1; i < categories.Length; ++i)
                    {
                        expCategories = ExpressionUtil<Book>.Or(expCategories, expFilterByCategory(categories[i]));
                    }
                    exp = ExpressionUtil<Book>.Combine(exp, expCategories);
                }
            }

            var books = _bookRepository.Filter(exp).ToList();
            var size = books.Count();
            // lọc theo số chương
            if (filter.ChapterRanges != null)
            {
                var chapterRanges = filter.ChapterRanges.ToArray();
                if (chapterRanges.Length > 0)
                {
                    for (int i = 0; i < size; ++i) 
                    {
                        var count = _chapterRepository.Filter(x => x.BookId == books[i].BookId).Count();
                        foreach (var range in chapterRanges)
                        {
                            if (count >= range.MinRange && count <= range.MaxRange) continue;
                            books.Remove(books[i]);
                            size--;
                            i--;
                        }
                    }
                }
            }

            // lọc theo tag
            // kiểm tra tag của những quyển đã có -> tag nào k có thì remove khỏi ds
            if (filter.TagIds != null)
            {
                var tags = filter.TagIds.ToArray();
                if (tags.Length > 0)
                {
                    for (int i = 0; i < size; ++i)
                    {
                        var bookTags = _bookTagRepository.Filter(x => x.BookId == books[i].BookId);
                        if (bookTags == null || bookTags.Count() == 0)
                        {
                            books.Remove(books[i]);
                            size--;
                            i--;
                            continue;
                        }
                        foreach (var tag in bookTags)
                        {
                            if (!tags.Contains(tag.TagId))
                            {
                                books.Remove(books[i]);
                                size--;
                                i--;
                                break;
                            }
                        }
                    }
                }
            }
            return _mapper.Map<List<Book>, List<BookModel>>(books);
        }

        //public IEnumerable<BookModel> GetAllBooks()
        //{
        //    var books = _bookRepository.GetAll();
        //    return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
        //}

        public BookModel GetById(string bookId)
        {
            var book = _bookRepository.GetById(bookId);
            return _mapper.Map<Book, BookModel>(book);
        }

        public BookModel Add(BookModel book)
        {
            var res = _bookRepository.Insert(_mapper.Map<BookModel, Book>(book));
            _bookRepository.Save();
            return _mapper.Map<Book, BookModel>(res);
        }
        public BookModel Update(BookModel book)
        {
            var res = _bookRepository.Update(_mapper.Map<BookModel, Book>(book));
            _bookRepository.Save();
            return _mapper.Map<Book, BookModel>(res);
        }
        public void DeleteTemporary(string bookId)
        {
            var book = _bookRepository.GetById(bookId);
            book.IsDeleted = true;
            _bookRepository.Update(book);
            _bookRepository.Save();
        }
        public void Delete(BookModel book)
        {
            _bookRepository.Delete(book);
            _bookRepository.Save();
        }

        public IEnumerable<BookModel> GetByUserInteractive(string userId, InteractionType type)
        {
            var list = _bookUserRepository.Filter(x => x.UserId == userId && x.InteractionId == (int)type).Select(x => x.BookId).ToList();
            var books = GetAll();
            books = books.Where(x => list.Contains(x.BookId));
            return books;
        }

        public IEnumerable<BookModel> GetByUser(string userId)
        {
            var books = _bookRepository.Filter(x => x.UserId == userId).ToList();
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
        }

        public IEnumerable<BookModel> GetByUploadStatus(int status)
        {
            var books = _bookRepository.Filter(x => x.Status == status).ToList();
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
        }

        public int CountInteractive(string bookId, InteractionType type)
        {
            var book = _bookRepository.GetById(bookId);
            var qtt = _bookUserRepository.Filter(x => x.BookId == bookId && x.InteractionId == (int)type).Count();
            return qtt;
        }

        public void SetStatus(string bookId, int status)
        {
            var book = _bookRepository.GetById(bookId);
            book.Status = status;
            _bookRepository.Update(book);
            _bookRepository.Save();
        }
    }
}
