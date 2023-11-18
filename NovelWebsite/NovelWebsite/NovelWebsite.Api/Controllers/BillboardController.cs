using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Domain.Services;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Domain.Services;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using System.Security.Cryptography;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [Route("/billboard")]
    [ApiController]
    public class BillboardController : ControllerBase
    {
        private readonly StatisticService _statisticService;
        private readonly BookService _bookService;
        private readonly ChapterService _chapterService;
        private readonly TagService _tagService;
        private readonly AuthorService _authorService;
        private readonly CategoryService _categoryService;
        public BillboardController(StatisticService statisticService,
                                   BookService bookService,
                                   ChapterService chapterService,
                                   TagService tagService,
                                   AuthorService authorService,
                                   CategoryService categoryService)
        {
            _statisticService = statisticService;
            _bookService = bookService;
            _chapterService = chapterService;
            _tagService = tagService;
            _authorService = authorService;
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("get-by-filter")]
        public IEnumerable<BookModel> GetByFilter(string category, string interaction, string sortOrder)
        {
            SortOrder ordDate = SortOrder.Descending;
            if (!string.IsNullOrEmpty(sortOrder)){
                if (int.TryParse(sortOrder, out int ord))
                {
                    ordDate = (SortOrder)ord;
                }
                else
                {
                    ordDate = (SortOrder)Enum.Parse(typeof(SortOrder), sortOrder, true);
                }
            }
            InteractionType type = InteractionType.View;
            if (!string.IsNullOrEmpty(interaction))
            {
                if (int.TryParse(interaction, out int sort))
                {
                    type = (InteractionType)sort;
                }
                else
                {
                    type = (InteractionType)Enum.Parse(typeof(InteractionType), sortOrder, true);
                }
            }
            var books = _bookService.GetAll();
            books = _statisticService.StatisticOfEachInteractionType(books, type);
            switch (ordDate)
            {
                case SortOrder.Descending:
                    books = books.OrderByDescending(x => x.CreatedDate);
                    break;
                case SortOrder.Ascending:
                    books = books.OrderBy(x => x.CreatedDate);
                    break;
                default:
                    books = books.OrderByDescending(x => x.CreatedDate);
                    break;
            }
            if (category != null)
            {
                books = books.Where(x => x.Category.Slug == category);
            }
            foreach (var book in books)
            {
                var author = _authorService.GetAuthorsById(book.AuthorId);
                book.Author = author;
                var cate = _categoryService.GetCategory(book.CategoryId);
                book.Category = cate;
                var tags = _tagService.GetTagsOfBook(book.BookId);
                book.Tags = tags;
                book.Likes = _bookService.CountInteractive(book.BookId, InteractionType.Like);
                book.Views = _bookService.CountInteractive(book.BookId, InteractionType.View);
                book.Recommends = _bookService.CountInteractive(book.BookId, InteractionType.Recommend);
                book.Follows = _bookService.CountInteractive(book.BookId, InteractionType.Follow);
                book.TotalChapters = _chapterService.GetChapters(book.BookId).Count();
            }
            return books;
        }
    }
}
