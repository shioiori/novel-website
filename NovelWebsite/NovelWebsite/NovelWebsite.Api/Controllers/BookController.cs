using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [Route("/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        private readonly IStatisticService _statisticService;
        private readonly IChapterService _chapterService;
        private readonly ITagService _tagService;
        private readonly IAuthorService _authorService;

        public BookController(IBookService bookService, 
                              IStatisticService statisticService, 
                              IChapterService chapterService,
                              ITagService tagService,
                              IAuthorService authorService)
        {
            _bookService = bookService;
            _statisticService = statisticService;
            _chapterService = chapterService;
            _tagService = tagService;
            _authorService = authorService;
        }

        [HttpGet]
        [Route("get-all")]
        public PagedList<BookModel> GetAll([FromQuery] PagedListRequest request){
            var books = _bookService.GetAll();
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [HttpGet]
        [Route("get-by-book-id")]
        public BookModel GetByBookId(string bookId){
            return _bookService.GetById(bookId);
        }

        [HttpGet]
        [Route("get-top-by-interaction-type")]
        public PagedList<BookModel> GetByInteractionType(InteractionType type, [FromQuery] PagedListRequest request)
        {
            var books = _bookService.GetAll();
            var res = _statisticService.StatisticOfEachInteractionType(books, type);
            return PagedList<BookModel>.ToPagedList(res, request);
        }

        [HttpGet]
        [Route("get-by-book-status")]
        public PagedList<BookModel> GetByBookStatus(string status, [FromQuery] PagedListRequest request){
            var books = _bookService.GetByBookStatus(status);
            foreach (var item in books)
            {
                item.TotalChapters = _chapterService.GetChapters(item.BookId).Count();
            }
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [HttpGet]
        [Route("get-by-author-id")]
        public PagedList<BookModel> GetByAuthor(int authorId, [FromQuery] PagedListRequest request)
        {
            var books = _bookService.GetByAuthor(authorId);
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [HttpGet]
        [Route("get-by-interaction-type")]
        public PagedList<BookModel> GetByInteractionType(string type, [FromQuery] PagedListRequest request)
        {
            IEnumerable<BookModel> books;
            if (int.TryParse(type, out var num)){
                books = _bookService.GetByUserInteractive((InteractionType)num);
            }
            books = _bookService.GetByUserInteractive((InteractionType)Enum.Parse(typeof (InteractionType), type, true));
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [HttpGet]
        [Route("get-by-filter")]
        public PagedList<BookModel> GetByFilter(FilterModel filter, [FromQuery] PagedListRequest request)
        {
            var books = _bookService.GetByFilter(filter);
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [HttpGet]
        [Route("get-by-name")]
        public PagedList<BookModel> GetByName(string name, [FromQuery] PagedListRequest request){
            var books = _bookService.GetByFilter(new FilterModel(){
                SearchName = name,
            });
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [HttpGet]
        [Route("get-by-category-id")]
        public PagedList<BookModel> GetByCategory(int categoryId, [FromQuery] PagedListRequest request)
        {
            var books = _bookService.GetByCategory(categoryId);
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("add")]
        public IActionResult Add(BookModel model){
            try { 
                if (model.UserId == null)
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    model.UserId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
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
    }
}
