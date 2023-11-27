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
using System.Security.Claims;
using static System.Reflection.Metadata.BlobBuilder;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [Route("/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;
        private readonly ChapterService _chapterService;
        private readonly TagService _tagService;
        private readonly AuthorService _authorService;
        private readonly CategoryService _categoryService;
        private readonly UserService _userService;

        public BookController(BookService bookService,
                              ChapterService chapterService,
                              TagService tagService,
                              AuthorService authorService,
                              CategoryService categoryService,
                              UserService userService)
        {
            _bookService = bookService;
            _chapterService = chapterService;
            _tagService = tagService;
            _authorService = authorService;
            _categoryService = categoryService;
            _userService = userService;
        }

        [HttpGet]
        [Route("get-all")]
        public PagedList<BookModel> GetAll([FromQuery] PagedListRequest request)
        {
            var books = _bookService.GetAll(request);
            return PagedList<BookModel>.ToPagedList(books);
        }

        [HttpGet]
        [Route("get-published-book")]
        public PagedList<BookModel> GetPublishedBook([FromQuery] PagedListRequest request)
        {
            var books = _bookService.GetByBookStatus(UploadStatus.Publish.ToString(), request);
            return PagedList<BookModel>.ToPagedList(books);
        }


        [HttpGet]
        [Route("get-by-book-id")]
        public async Task<BookModel> GetByBookIdAsync(string bookId)
        {
            var book = await _bookService.GetByIdAsync(bookId);
            return book;
        }

        [HttpGet]
        [Route("get-top-by-interaction-type")]
        public PagedList<BookModel> GetByInteractionType(InteractionType type, [FromQuery] PagedListRequest request)
        {
            var init = _bookService.GetAll();
            var books = _bookService.GetTopEachInteractionType(init, type);
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [HttpGet]
        [Route("get-by-book-status")]
        public PagedList<BookModel> GetByBookStatus(string status, [FromQuery] PagedListRequest request)
        {
            var books = _bookService.GetByBookStatus(status, request);
            return PagedList<BookModel>.ToPagedList(books);
        }

        [HttpGet]
        [Route("get-by-status")]
        public PagedList<BookModel> GetByUploadStatus(string status, [FromQuery] PagedListRequest request)
        {
            IEnumerable<BookModel> books;
            if (int.TryParse(status, out var num))
            {
                books = _bookService.GetByUploadStatus((UploadStatus)num, request);
            }
            else
            {
                books = _bookService.GetByUploadStatus((UploadStatus)Enum.Parse(typeof(UploadStatus), status, true), request);
            }
            return PagedList<BookModel>.ToPagedList(books);
        }

        [HttpGet]
        [Route("get-by-author-id")]
        public PagedList<BookModel> GetByAuthor(int authorId, [FromQuery] PagedListRequest request)
        {
            var books = _bookService.GetByAuthor(authorId, request);
            return PagedList<BookModel>.ToPagedList(books);
        }

        [HttpGet]
        [Route("get-by-interaction-type")]
        public PagedList<BookModel> GetByInteractionType(string userId, string type, [FromQuery] PagedListRequest request)
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
            IEnumerable<BookModel> books;
            if (int.TryParse(type, out var num))
            {
                books = _bookService.GetByUserInteractive(userId, (InteractionType)num);
            }
            else
            {
                books = _bookService.GetByUserInteractive(userId, (InteractionType)Enum.Parse(typeof(InteractionType), type, true));
            }
            return PagedList<BookModel>.ToPagedList(books);
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
            var books = _bookService.GetByUser(userId, request);
            return PagedList<BookModel>.ToPagedList(books);
        }

        [HttpGet]
        [Route("get-by-filter")]
        public async Task<PagedList<BookModel>> GetByFilterAsync([FromQuery] FilterModel filter, [FromQuery] PagedListRequest request)
        {
            var books = await _bookService.GetByFilterAsync(filter, request);
            return PagedList<BookModel>.ToPagedList(books);
        }

        [HttpGet]
        [Route("get-by-name")]
        public async Task<PagedList<BookModel>> GetByNameAsync(string name, [FromQuery] PagedListRequest request)
        {
            var books = await _bookService.GetByFilterAsync(new FilterModel()
            {
                SearchName = name,
            }, request);
            return PagedList<BookModel>.ToPagedList(books);
        }

        [HttpGet]
        [Route("get-by-category-id")]
        public PagedList<BookModel> GetByCategory(int categoryId, [FromQuery] PagedListRequest request)
        {
            var books = _bookService.GetByCategory(categoryId, request);
            return PagedList<BookModel>.ToPagedList(books);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync(BookModel model)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                model.UserId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                if (model.Author != null && model.AuthorId == 0)
                {
                    var author = _authorService.GetAuthorByNameAsync(model.Author.AuthorName);
                    if (author == null)
                    {
                        await _authorService.CreateAuthorAsync(model.Author);
                        model.AuthorId = (await _authorService.GetAuthorByNameAsync(model.Author.AuthorName)).AuthorId;
                    }
                }
                var book = await _bookService.AddAsync(model);
                if (model.Tags != null)
                {
                    _tagService.AddTagsOfBookAsync(book.BookId, model.Tags);
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
        public async Task<IActionResult> UpdateAsync(BookModel model)
        {
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
                    var author = _authorService.GetAuthorByNameAsync(model.Author.AuthorName);
                    if (author == null)
                    {
                        await _authorService.CreateAuthorAsync(model.Author);
                        model.AuthorId = (await _authorService.GetAuthorByNameAsync(model.Author.AuthorName)).AuthorId;
                    }
                }
                _bookService.UpdateAsync(model);
                if (model.Tags != null)
                {
                    _tagService.AddTagsOfBookAsync(model.BookId, model.Tags);
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
        public IActionResult Delete(string bookId)
        {
            try
            {
                _bookService.DeleteTemporaryAsync(bookId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        [Route("set-status")]
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
                _bookService.SetStatusAsync(bookId, stt);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
