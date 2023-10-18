using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Constants;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;

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
        public IEnumerable<BookModel> GetAll(){
            return _bookService.GetAllBooks();
        }

        [HttpGet]
        [Route("get-by-book-id")]
        public BookModel GetByBookId(int bookId){
            return _bookService.GetBook(bookId);
        }

        [HttpGet]
        [Route("get-top-by-interaction-type")]
        public IEnumerable<BookModel> GetByInteractionType(InteractionType type)
        {
            var books = _bookService.GetBooks();
            var res = _statisticService.StatisticOfEachInteractionType(books, type);
            return res;
        }

        [HttpGet]
        [Route("get-by-book-status")]
        public IEnumerable<BookModel> GetByBookStatus(string status){
            var books = _bookService.GetBooksByBookStatus(status);
            foreach (var item in books)
            {
                item.TotalChapters = _chapterService.GetChapters(item.BookId).Count();
            }
            return books;
        }

        [HttpGet]
        [Route("get-by-author")]
        public IEnumerable<BookModel> GetByAuthor(int authorId){
            return _bookService.GetBooksByAuthor(authorId);
        }

        [HttpGet]
        [Route("get-by-interaction-type")]
        public IEnumerable<BookModel> GetByInteractionType(string type){
            if (int.TryParse(type, out var num)){
                return _bookService.GetBookByUserInteractive((InteractionType)num);
            }
            return _bookService.GetBookByUserInteractive((InteractionType)Enum.Parse(typeof (InteractionType), type, true));
        }

        [HttpGet]
        [Route("get-by-filter")]
        public IEnumerable<BookModel> GetByFilter(FilterModel filter){
            return _bookService.GetBooksByFilter(filter);
        }

        [HttpGet]
        [Route("get-by-name")]
        public IEnumerable<BookModel> GetByName(string name){
            return _bookService.GetBooksByFilter(new FilterModel(){
                SearchName = name,
            });
        }

        [HttpGet]
        [Route("get-by-category")]
        public IEnumerable<BookModel> GetByCategory(int categoryId){
            return _bookService.GetBooksByCategory(categoryId);
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
