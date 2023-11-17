using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NovelWebsite.Domain.Services;
using NovelWebsite.NovelWebsite.Core.Constants;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models.Response;
using NovelWebsite.NovelWebsite.Domain.Services;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Security.Claims;
using static System.Reflection.Metadata.BlobBuilder;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [Route("/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        private readonly StatisticService _statisticService;
        private readonly ChapterService _chapterService;
        private readonly TagService _tagService;
        private readonly AuthorService _authorService;
        private readonly CategoryService _categoryService;
        private readonly UserService _userService;

        public BookController(BookService bookService, 
                              StatisticService statisticService, 
                              ChapterService chapterService,
                              TagService tagService,
                              AuthorService authorService, 
                              CategoryService categoryService,
                              UserService userService)
        {
            _bookService = bookService;
            _statisticService = statisticService;
            _chapterService = chapterService;
            _tagService = tagService;
            _authorService = authorService;
            _categoryService = categoryService;
            _userService = userService;
        }

        [HttpGet]
        [Route("get-all")]
        public PagedList<BookModel> GetAll([FromQuery] PagedListRequest request){
            var books = _bookService.GetAll().ToArray();
            int count = books.Length;
            for (int i = 0; i < count; ++i)
            {
                BindModelAsync(ref books[i]);
            }
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [HttpGet]
        [Route("get-by-book-id")]
        public BookModel GetByBookId(string bookId){
            var book = _bookService.GetById(bookId);
            BindModelAsync(ref book);
            return book;
        }

        [HttpGet]
        [Route("get-top-by-interaction-type")]
        public PagedList<BookModel> GetByInteractionType(InteractionType type, [FromQuery] PagedListRequest request)
        {
            var books = _bookService.GetAll();
            var res = _statisticService.StatisticOfEachInteractionType(books, type).ToArray();
            int count = res.Length;
            for (int i = 0; i < count; ++i)
            {
                BindModelAsync(ref res[i]);
            };
            return PagedList<BookModel>.ToPagedList(res, request);
        }

        [HttpGet]
        [Route("get-by-book-status")]
        public PagedList<BookModel> GetByBookStatus(string status, [FromQuery] PagedListRequest request){
            var books = _bookService.GetByBookStatus(status).ToArray();
            int count = books.Length;
            for (int i = 0; i < count; ++i)
            {
                BindModelAsync(ref books[i]);
            }
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [HttpGet]
        [Route("get-by-author-id")]
        public PagedList<BookModel> GetByAuthor(int authorId, [FromQuery] PagedListRequest request)
        {
            var books = _bookService.GetByAuthor(authorId).ToArray();
            int count = books.Length;
            for (int i = 0; i < count; ++i)
            {
                BindModelAsync(ref books[i]);
            };
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [HttpGet]
        [Route("get-by-interaction-type")]
        public PagedList<BookModel> GetByInteractionType(string type, [FromQuery] PagedListRequest request)
        {
            BookModel[] books;
            if (int.TryParse(type, out var num))
            {
                books = _bookService.GetByUserInteractive((InteractionType)num).ToArray();
            }
            else
            {
                books = _bookService.GetByUserInteractive((InteractionType)Enum.Parse(typeof(InteractionType), type, true)).ToArray();
            }
            int count = books.Length;
            for (int i = 0; i < count; ++i)
            {
                BindModelAsync(ref books[i]);
            };
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [HttpGet]
        [Route("get-by-user")]
        public PagedList<BookModel> GetByUser(string? userId, [FromQuery] PagedListRequest request)
        {
            if (userId == null)
            {
                try
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            var books = _bookService.GetByUser(userId).ToArray();
            int count = books.Length;
            for (int i = 0; i < count; ++i)
            {
                BindModelAsync(ref books[i]);
            };
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [HttpGet]
        [Route("get-by-filter")]
        public async Task<PagedList<BookModel>> GetByFilterAsync([FromQuery] FilterModel filter, [FromQuery] PagedListRequest request)
        {
            var books = _bookService.GetByFilter(filter).ToArray();
            int count = books.Length;
            for (int i = 0; i < count; ++i)
            {
                BindModelAsync(ref books[i]);
            }
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [HttpGet]
        [Route("get-by-name")]
        public PagedList<BookModel> GetByName(string name, [FromQuery] PagedListRequest request){
            var books = _bookService.GetByFilter(new FilterModel(){
                SearchName = name,
            }).ToArray();
            int count = books.Length;
            for (int i = 0; i < count; ++i)
            {
                BindModelAsync(ref books[i]);
            };
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [HttpGet]
        [Route("get-by-category-id")]
        public PagedList<BookModel> GetByCategory(int categoryId, [FromQuery] PagedListRequest request)
        {
            var books = _bookService.GetByCategory(categoryId).ToArray();
            int count = books.Length;
            for (int i = 0; i < count; ++i)
            {
                BindModelAsync(ref books[i]);
            };
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("add")]
        public IActionResult Add(BookModel model){
            try { 
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                model.UserId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                if (model.Author != null && model.AuthorId == 0)
                {
                    var author = _authorService.GetAuthorByName(model.Author.AuthorName);
                    if (author == null)
                    {
                        _authorService.CreateAuthor(model.Author);
                        model.AuthorId = author.AuthorId;
                    }
                }
                var book = _bookService.Add(model);
                if (model.Tags != null)
                {
                    _tagService.AddTagsOfBook(book.BookId, model.Tags);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("update")]
        public IActionResult Update(BookModel model){
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                model.UserId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                if (model.BookId == null)
                {
                    return BadRequest();
                }
                if (model.Author != null && model.AuthorId == 0)
                {
                    var author = _authorService.GetAuthorByName(model.Author.AuthorName);
                    if (author == null)
                    {
                        _authorService.CreateAuthor(model.Author);
                        model.AuthorId = author.AuthorId;
                    }
                }
                var book = _bookService.Update(model);
                if (model.Tags != null)
                {
                    _tagService.AddTagsOfBook(book.BookId, model.Tags);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(string bookId){
            try
            {
                _bookService.DeleteTemporary(bookId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Editor")]
        [HttpPut]
        [Route("set-book-status")]
        public IActionResult SetStatusBook(string bookId, string status)
        {
            try
            {
                int stt;
                if (int.TryParse(status, out var num))
                {
                    stt = num;
                }
                else
                {
                    stt = (int)((UploadStatus)Enum.Parse(typeof(UploadStatus), status, true));
                }
                _bookService.SetStatus(bookId, stt);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [NonAction]
        public BookModel BindModelAsync(ref BookModel book)
        {
            var author = _authorService.GetAuthorsById(book.AuthorId);
            book.Author = author;
            var category = _categoryService.GetCategory(book.CategoryId);
            book.Category = category;
            var tags = _tagService.GetTagsOfBook(book.BookId);
            book.Tags = tags;
            book.Likes = _bookService.CountInteractive(book.BookId, InteractionType.Like);
            book.Views = _bookService.CountInteractive(book.BookId, InteractionType.View);
            book.Recommends = _bookService.CountInteractive(book.BookId, InteractionType.Recommend);
            book.Follows = _bookService.CountInteractive(book.BookId, InteractionType.Follow);
            book.TotalChapters = _chapterService.GetChapters(book.BookId).Count();
            return book;
        }
    }
}
