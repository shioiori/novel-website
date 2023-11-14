using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Constants;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models.Response;
using Org.BouncyCastle.Asn1.Ocsp;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [Route("/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        private readonly IStatisticService _statisticService;
        private readonly IChapterService _chapterService;

        public BookController(IBookService bookService, IStatisticService statisticService, 
                              IChapterService chapterService)
        {
            _bookService = bookService;
            _statisticService = statisticService;
            _chapterService = chapterService;
        }

        [HttpGet]
        [Route("get-all")]
        public PagedList<BookModel> GetAll([FromQuery] PagedListRequest request){
            var books = _bookService.GetAllBooks();
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [HttpGet]
        [Route("get-by-book-id")]
        public BookModel GetByBookId(int bookId){
            return _bookService.GetBook(bookId);
        }

        [HttpGet]
        [Route("get-top-by-interaction-type")]
        public PagedList<BookModel> GetByInteractionType(InteractionType type, [FromQuery] PagedListRequest request)
        {
            var books = _bookService.GetBooks();
            var res = _statisticService.StatisticOfEachInteractionType(books, type);
            return PagedList<BookModel>.ToPagedList(res, request);
        }

        [HttpGet]
        [Route("get-by-book-status")]
        public PagedList<BookModel> GetByBookStatus(string status, [FromQuery] PagedListRequest request){
            var books = _bookService.GetBooksByBookStatus(status);
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
            var books = _bookService.GetBooksByAuthor(authorId);
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [HttpGet]
        [Route("get-by-interaction-type")]
        public PagedList<BookModel> GetByInteractionType(string type, [FromQuery] PagedListRequest request)
        {
            IEnumerable<BookModel> books;
            if (int.TryParse(type, out var num)){
                books = _bookService.GetBookByUserInteractive((InteractionType)num);
            }
            books = _bookService.GetBookByUserInteractive((InteractionType)Enum.Parse(typeof (InteractionType), type, true));
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [HttpGet]
        [Route("get-by-filter")]
        public PagedList<BookModel> GetByFilter(FilterModel filter, [FromQuery] PagedListRequest request)
        {
            var books = _bookService.GetBooksByFilter(filter);
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [HttpGet]
        [Route("get-by-name")]
        public PagedList<BookModel> GetByName(string name, [FromQuery] PagedListRequest request){
            var books = _bookService.GetBooksByFilter(new FilterModel(){
                SearchName = name,
            });
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [HttpGet]
        [Route("get-by-category-id")]
        public PagedList<BookModel> GetByCategory(int categoryId, [FromQuery] PagedListRequest request)
        {
            var books = _bookService.GetBooksByCategory(categoryId);
            return PagedList<BookModel>.ToPagedList(books, request);
        }

        [HttpPost]
        [Route("add")]
        public void Add(BookModel model){
            _bookService.CreateBook(model);
        }

        [HttpPost]
        [Route("update")]
        public void Update(BookModel model){
            _bookService.UpdateBook(model);
        }

        [HttpDelete]
        [Route("delete")]
        public void Delete(int bookId){
            _bookService.DeleteBook(bookId);
        }
    }
}
