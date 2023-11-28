using Application.Utils;
using Application.Models.Dtos;
using NovelWebsite.Domain.Entities;
using System.Linq.Expressions;
using NovelWebsite.Domain.Enums;
using NovelWebsite.Domain.Interfaces;
using Application.Services.Base;
using NovelWebsite.Application.Models.Request;
using NovelWebsite.Application.Utils;
using Microsoft.EntityFrameworkCore;
using Application.Models.Objects.Filter;

namespace NovelWebsite.Domain.Services
{
    public class BookService : GenericService<Book, BookDto>
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IBookUserRepository _bookUserRepository;
        private readonly IBookTagRepository _bookTagRepository;
        private readonly ITagRepository _tagRepository;

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

        public BookService(
            IBookUserRepository bookUserRepository, 
            IChapterRepository chapterRepository,
            IBookTagRepository bookTagRepository
            ) : base()
        {
            _bookUserRepository = bookUserRepository;
            _chapterRepository = chapterRepository;
            _bookTagRepository = bookTagRepository;
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync(PagedListRequest pagedListRequest = null)
        {
            var query = _repository.Get(expValidBooks);
            var books = PagedList<Book>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(books);
        }

        public async Task<IEnumerable<BookDto>> GetByAuthorAsync(int authorId, PagedListRequest pagedListRequest = null)
        {
            var exp = ExpressionCombine<Book>.And(expValidBooks, expFilterByAuthor(authorId));
            var query = _repository.Get(exp);
            var books = PagedList<Book>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(books);
        }

        public async Task<IEnumerable<BookDto>> GetByCategoryAsync(int categoryId, PagedListRequest pagedListRequest = null)
        {
            var exp = ExpressionCombine<Book>.And(expValidBooks, expFilterByCategory(categoryId));
            var query = _repository.Get(exp);
            var books = PagedList<Book>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(books);
        }

        public async Task<IEnumerable<BookDto>> GetByBookStatusAsync(string status, PagedListRequest pagedListRequest = null)
        {
            var exp = ExpressionCombine<Book>.And(expValidBooks, expFilterByBookStatus(status));
            var query = _repository.Get(exp);
            var books = PagedList<Book>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(books);
        }

        public async Task<IEnumerable<BookDto>> GetFromTimeAsync(DateTime start, PagedListRequest pagedListRequest = null)
        {
            var query = _repository.Get(expFromTime(start));
            var books = PagedList<Book>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(books);
        }

        public async Task<IEnumerable<BookDto>> MapDtosAsync(BookFilter filter, PagedListRequest pagedListRequest = null)
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
                        expBookStatuses = ExpressionCombine<Book>.Or(expBookStatuses, expFilterByBookStatus(bookStatuses[i]));
                    }
                    exp = ExpressionCombine<Book>.And(exp, expBookStatuses);
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
                        expCategories = ExpressionCombine<Book>.Or(expCategories, expFilterByCategory(categories[i]));
                    }
                    exp = ExpressionCombine<Book>.And(exp, expCategories);
                }
            }

            var books = _repository.Get(exp).ToList();
            var size = books.Count();
            // lọc theo số chương
            if (filter.ChapterRanges != null)
            {
                var chapterRanges = filter.ChapterRanges.ToArray();
                if (chapterRanges.Length > 0)
                {
                    for (int i = 0; i < size; ++i) 
                    {
                        var count = _chapterRepository.Get().Count(x => x.BookId == books[i].BookId);
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
                        var bookTags = _bookTagRepository.Get(x => x.BookId == books[i].BookId);
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
            return await MapDtosAsync(books);
        }

        public async Task<BookDto> MapDtosAsync(string bookId)
        {
            var book = await _repository.Get(x => x.BookId == bookId).FirstOrDefaultAsync();
            return await MapDtosAsync(book);
        }

        public async Task<IEnumerable<BookDto>> GetByUserInteractiveAsync(string userId, InteractionType type, PagedListRequest pagedListRequest = null)
        {
            var expBookUser = ExpressionCombine<BookUsers>.And(expFilterBookUser(userId), expFilterByInteractionType(type));
            var list = _bookUserRepository.Get(expBookUser).Select(x => x.BookId);
            var expBook = ExpressionCombine<Book>.And(expValidBooks, x => list.Contains(x.BookId));
            var query = _repository.Get(expBook);
            var books = PagedList<Book>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(books);
        }

        public async Task<IEnumerable<BookDto>> GetByUserAsync(string userId, PagedListRequest pagedListRequest = null)
        {
            var query = _repository.Get(expFilterUser(userId));
            var books = PagedList<Book>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(books);
        }

        public async Task<IEnumerable<BookDto>> GetByUploadStatusAsync(UploadStatus status, PagedListRequest pagedListRequest = null)
        {
            var query = _repository.Get(expFilterByUploadStatus(status)).ToList();
            var books = PagedList<Book>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(books);
        }

        public async Task<int> MapDtosAsync(string bookId, InteractionType type)
        {
            var book = _repository.Get(x => x.BookId == bookId);
            return await _bookUserRepository.Get().CountAsync(x => x.BookId == bookId && x.InteractionId == (int)type);
        }

        public async Task MapDtosAsync(string bookId, int status)
        {
            var book = _repository.Get(x => x.BookId == bookId).FirstOrDefault();
            book.Status = status;
            await _repository.UpdateAsync(book);
            _repository.SaveAsync();
        }

        public Task<IEnumerable<BookDto>> GetBillboard(Billboard filter)
        {
            var bookQuery = _repository.Get();
            if (filter.CategoryId != 0)
            {
                bookQuery = bookQuery.Where(x => x.CategoryId == filter.CategoryId);
            }
            if (filter.Reaction == (int)InteractionType.View)
            {
                if (filter.OrderBy == (int)SortOrder.Ascending)
                {
                    return MapDtosAsync(bookQuery.OrderByDescending(x => x.Views));
                }
                else
                {
                    return MapDtosAsync(bookQuery.OrderBy(x => x.Views));
                }
            }
            else
            {
                var bookUser = _bookUserRepository.Get(expFilterByInteractionType((InteractionType)filter.Reaction))
                                                    .GroupBy(b => b.BookId)
                                                    .OrderByDescending(g => g.Count())
                                                    .Select(g => new
                                                    {
                                                        BookId = g.Key,
                                                        InteractionCount = g.Count(),
                                                        InteractionType = (InteractionType)filter.Reaction,
                                                    }).ToList();
                if (filter.OrderBy == (int)SortOrder.Ascending)
                {
                    var books = bookQuery.AsEnumerable().OrderBy(b =>
                    {
                        var index = bookUser.FindIndex(x => x.BookId == b.BookId);
                        return index == -1 ? bookUser.Count : index;
                    }).AsEnumerable();
                    return MapDtosAsync(books);
                }
                else
                {
                    var books = bookQuery.AsEnumerable().OrderBy(b =>
                    {
                        var index = bookUser.FindIndex(x => x.BookId == b.BookId);
                        return index == -1 ? index : bookUser.Count;
                    }).AsEnumerable();
                    return MapDtosAsync(books);
                }
            }
        }

    }
}
