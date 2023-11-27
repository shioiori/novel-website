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
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models.Response;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NovelWebsite.Domain.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IChapterRepository _chapterRepository;
        private readonly IBookUserRepository _bookUserRepository;
        private readonly IBookTagRepository _bookTagRepository;
        private readonly ITagRepository _tagRepository;
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

        Expression<Func<Book, bool>> expFilterUser(string id)
        {
            return x => x.UserId == id;
        }
        Expression<Func<Book, bool>> expSearchName(string name) {
            return x => string.IsNullOrEmpty(name)
                        || x.BookName.ToLower().Trim().Contains(name.ToLower().Trim());
        }
        Expression<Func<BookUsers, bool>> expFilterByInteractionType(InteractionType type)
        {
            return b => b.InteractionId == (int)type;
        }
        Expression<Func<BookUsers, bool>> expFilterBookUser(string id)
        {
            return x => x.UserId == id;
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

        public IEnumerable<BookModel> GetAll(PagedListRequest pagedListRequest = null)
        {
            var query = _bookRepository.Filter(expValidBooks);
            var books = PagedList<Book>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
        }

        public IEnumerable<BookModel> GetByAuthor(int authorId, PagedListRequest pagedListRequest = null)
        {
            var exp = ExpressionUtil<Book>.Combine(expValidBooks, expFilterByAuthor(authorId));
            var query = _bookRepository.Filter(exp);
            var books = PagedList<Book>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
        }

        public IEnumerable<BookModel> GetByCategory(int categoryId, PagedListRequest pagedListRequest = null)
        {
            var exp = ExpressionUtil<Book>.Combine(expValidBooks, expFilterByCategory(categoryId));
            var query = _bookRepository.Filter(exp);
            var books = PagedList<Book>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
        }

        public IEnumerable<BookModel> GetByBookStatus(string status, PagedListRequest pagedListRequest = null)
        {
            var exp = ExpressionUtil<Book>.Combine(expValidBooks, expFilterByBookStatus(status));
            var query = _bookRepository.Filter(exp);
            var books = PagedList<Book>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
        }

        public IEnumerable<BookModel> GetFromTime(DateTime start, PagedListRequest pagedListRequest = null)
        {
            var query = _bookRepository.Filter(expFromTime(start));
            var books = PagedList<Book>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
        }

        public async Task<IEnumerable<BookModel>> GetByFilterAsync(FilterModel filter, PagedListRequest pagedListRequest = null)
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
                        var count = await _chapterRepository.CountAsync(x => x.BookId == books[i].BookId);
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
            var res = PagedList<Book>.AsEnumerable(books, pagedListRequest);
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(res);
        }

        public async Task<BookModel> GetByIdAsync(string bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            return _mapper.Map<Book, BookModel>(book);
        }

        public async Task<BookModel> AddAsync(BookModel book)
        {
            var res = await _bookRepository.InsertAsync(_mapper.Map<BookModel, Book>(book));
            _bookRepository.SaveAsync();
            return _mapper.Map<Book, BookModel>(res);
        }

        public async Task<BookModel> UpdateAsync(BookModel book)
        {
            var res = await _bookRepository.UpdateAsync(_mapper.Map<BookModel, Book>(book));
            _bookRepository.SaveAsync();
            return _mapper.Map<Book, BookModel>(res);
        }
        public async Task DeleteTemporaryAsync(string bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            book.IsDeleted = true;
            await _bookRepository.UpdateAsync(book);
            _bookRepository.SaveAsync();
        }
        public async Task DeleteAsync(BookModel book)
        {
            await _bookRepository.DeleteAsync(book);
            _bookRepository.SaveAsync();
        }

        public IEnumerable<BookModel> GetByUserInteractive(string userId, InteractionType type, PagedListRequest pagedListRequest = null)
        {
            var expBookUser = ExpressionUtil<BookUsers>.Combine(expFilterBookUser(userId), expFilterByInteractionType(type));
            var list = _bookUserRepository.Filter(expBookUser).Select(x => x.BookId);
            var expBook = ExpressionUtil<Book>.Combine(expValidBooks, x => list.Contains(x.BookId));
            var query = _bookRepository.Filter(expBook);
            var books = PagedList<Book>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
        }

        public IEnumerable<BookModel> GetByUser(string userId, PagedListRequest pagedListRequest = null)
        {
            var query = _bookRepository.Filter(expFilterUser(userId));
            var books = PagedList<Book>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
        }

        public IEnumerable<BookModel> GetByUploadStatus(UploadStatus status, PagedListRequest pagedListRequest = null)
        {
            var query = _bookRepository.Filter(expFilterByUploadStatus(status)).ToList();
            var books = PagedList<Book>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(books);
        }

        public async Task<int> CountInteractiveAsync(string bookId, InteractionType type)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            return await _bookUserRepository.CountAsync(x => x.BookId == bookId && x.InteractionId == (int)type);
        }

        public async Task SetStatusAsync(string bookId, int status)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            book.Status = status;
            await _bookRepository.UpdateAsync(book);
            _bookRepository.SaveAsync();
        }

        public IEnumerable<BookModel> GetTopEachInteractionType(IEnumerable<BookModel> books, InteractionType type)
        {
            if (type == InteractionType.View)
            {
                books = books.OrderByDescending(x => x.Views);
                return books;
            }
            var list = _bookUserRepository.Filter(expFilterByInteractionType(type))
                             .GroupBy(b => b.BookId)
                             .OrderByDescending(g => g.Count())
                             .Select(g => new
                             {
                                 BookId = g.Key,
                                 InteractionCount = g.Count(),
                                 InteractionType = type,
                             }).ToList();
            books = books.OrderBy(b =>
            {
                var index = list.FindIndex(x => x.BookId == b.BookId);
                return index == -1 ? list.Count : index;
            });
            return books;
        }

    }
}
