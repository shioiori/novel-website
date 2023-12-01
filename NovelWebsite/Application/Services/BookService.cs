using NovelWebsite.Application.Utils;
using NovelWebsite.Application.Models.Dtos;
using NovelWebsite.Domain.Entities;
using System.Linq.Expressions;
using NovelWebsite.Domain.Enums;
using NovelWebsite.Domain.Interfaces;
using Application.Services.Base;
using NovelWebsite.Application.Models.Requests;
using NovelWebsite.Application.Utils;
using NovelWebsite.Application.Models.Filters;
using AutoMapper;
using NovelWebsite.Application.Interfaces;

namespace NovelWebsite.Domain.Services
{
    public class BookService : GenericService<Book, BookDto>, IBookService
    {
        private readonly IBookTagRepository _bookTagRepository;


        public BookService(IBookRepository bookRepository,
            IBookTagRepository bookTagRepository,
            IMapper mapper
            ) : base(bookRepository, mapper)
        {
            _bookTagRepository = bookTagRepository;
        }
        public async Task<IEnumerable<BookDto>> FilterAsync(BookFilter filter, PagedListRequest request)
        {
            var query = _repository.Get();
            // no filter apply
            if (filter == null)
            {
                return await MapDtosAsync(query.AsEnumerable());
            }

            // search name
            Expression<Func<Book, bool>> exp = x => string.IsNullOrEmpty(filter.SearchName)
                        || x.BookName.ToLower().Trim().Contains(filter.SearchName.ToLower().Trim());

            // is deleted?
            exp = ExpressionCombine<Book>.And(exp, x => x.IsDeleted == filter.IsDeleted);

            // book statuses, accept one in all
            if (filter.BookStatuses != null)
            {
                var bookStatuses = filter.BookStatuses.ToArray();
                if (bookStatuses.Length > 0)
                {
                    Expression<Func<Book, bool>> expBookStatuses = x => x.BookStatus == bookStatuses[0];
                    for (int i = 1; i < bookStatuses.Length; ++i)
                    {
                        expBookStatuses = ExpressionCombine<Book>.Or(expBookStatuses, x => x.BookStatus == bookStatuses[i]);
                    }
                    exp = ExpressionCombine<Book>.And(exp, expBookStatuses);
                }
            }

            // categories, accept one in all
            if (filter.CategoryIds != null)
            {
                var categories = filter.CategoryIds.ToArray();
                if (categories.Length > 0)
                {
                    Expression<Func<Book, bool>> expCategories = x => x.CategoryId == categories[0];
                    for (int i = 1; i < categories.Length; ++i)
                    {
                        expCategories = ExpressionCombine<Book>.Or(expCategories, x => x.CategoryId == categories[i]);
                    }
                    exp = ExpressionCombine<Book>.And(exp, expCategories);
                }
            }

            // created date
            if (filter.CreatedMin != DateTime.MinValue)
            {
                exp = ExpressionCombine<Book>.And(exp, x => x.CreatedDate >= filter.CreatedMin);
            }
            if (filter.CreatedMax != DateTime.MinValue)
            {
                exp = ExpressionCombine<Book>.And(exp, x => x.CreatedDate <= filter.CreatedMax);
            }

            // updated date
            if (filter.UpdatedMin != DateTime.MinValue)
            {
                exp = ExpressionCombine<Book>.And(exp, x => x.UpdatedDate >= filter.UpdatedMin);
            }
            if (filter.UpdatedMax != DateTime.MinValue)
            {
                exp = ExpressionCombine<Book>.And(exp, x => x.UpdatedDate <= filter.UpdatedMax);
            }

            // user
            if (filter.UserId != null)
            {
                exp = ExpressionCombine<Book>.And(exp, x => x.UserId == filter.UserId);
            }

            // author
            if (filter.AuthorId != null)
            {
                exp = ExpressionCombine<Book>.And(exp, x => x.AuthorId == filter.AuthorId);

            }

            // upload status
            if (filter.UploadStatus != null)
            {
                exp = ExpressionCombine<Book>.And(exp, x => x.Status == (int)filter.UploadStatus);
            }

            // chapter range
            if (filter.MinRange != null)
            {
                exp = ExpressionCombine<Book>.And(exp, x => x.TotalChapters >= filter.MinRange);
            }
            if (filter.MaxRange != null)
            {
                exp = ExpressionCombine<Book>.And(exp, x => x.TotalChapters <= filter.MaxRange);
            }

            // interaction
            if (filter.InteractionType != null)
            {
                switch (filter.InteractionType)
                {
                    case InteractionType.Like:
                        query = query.OrderByDescending(x => x.Likes);
                        break;
                    case InteractionType.View:
                        query = query.OrderByDescending(x => x.Views);
                        break;
                    case InteractionType.Follow:
                        query = query.OrderByDescending(x => x.Follows);
                        break;
                    case InteractionType.Recommend:
                        query = query.OrderByDescending(x => x.Recommend);
                        break;
                    default:
                        break;

                }
            }

            // must include all tags, check if book not include all then remove
            var books = PagedList<Book>.AsEnumerable(query, request).ToList();
            if (filter.TagIds != null)
            {
                int size = books.Count();
                var tags = filter.TagIds.ToArray();
                if (tags.Length > 0)
                {
                    for (int i = 0; i < size; ++i)
                    {
                        var bookTags = _bookTagRepository.Get(x => x.BookId == books[i].BookId).Select(x => x.Tag.TagId);
                        if (bookTags == null || bookTags.Count() == 0)
                        {
                            books.Remove(books[i]);
                            size--;
                            i--;
                            continue;
                        }
                        foreach (var tag in bookTags)
                        {
                            if (!tags.Contains(tag))
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
            return await MapDtosAsync(books);
        }
        public async Task<IEnumerable<BookDto>> FilterAsync(BillboardFilter filter, PagedListRequest request)
        {
            var bookQuery = _repository.Get();
            if (filter.CategoryId != null)
            {
                bookQuery = bookQuery.Where(x => x.CategoryId == filter.CategoryId);
            }
            if (filter.OrderBy == (int)SortOrder.Ascending)
            {
                switch (filter.InteractionType)
                {
                    case InteractionType.Like:
                        bookQuery = bookQuery.OrderBy(x => x.Likes);
                        break;
                    case InteractionType.View:
                        bookQuery = bookQuery.OrderBy(x => x.Views);
                        break;
                    case InteractionType.Follow:
                        bookQuery = bookQuery.OrderBy(x => x.Follows);
                        break;
                    case InteractionType.Recommend:
                        bookQuery = bookQuery.OrderBy(x => x.Recommend);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (filter.InteractionType)
                {
                    case InteractionType.Like:
                        bookQuery = bookQuery.OrderByDescending(x => x.Likes);
                        break;
                    case InteractionType.View:
                        bookQuery = bookQuery.OrderByDescending(x => x.Views);
                        break;
                    case InteractionType.Follow:
                        bookQuery = bookQuery.OrderByDescending(x => x.Follows);
                        break;
                    case InteractionType.Recommend:
                        bookQuery = bookQuery.OrderByDescending(x => x.Recommend);
                        break;
                    default:
                        break;
                }
            }
            return await MapDtosAsync(PagedList<Book>.AsEnumerable(bookQuery, request));
        }
        public async Task<BookDto> GetByIdAsync(string id)
        {
            var book = _repository.Get().FirstOrDefault(x => x.BookId == id);
            return await MapDtoAsync(book);
        }

    }
}
