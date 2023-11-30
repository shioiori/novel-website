using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Filter;
using Application.Utils;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Controllers.Base;

namespace NovelWebsite.Controllers
{
    [Route("/billboard")]
    [ApiController]
    public class BillboardController : BaseController<BookDto>
    {
        private readonly IBookService _bookService;
        public BillboardController(IBookService bookService) : base(bookService) { 
            _bookService = bookService;
        }

        [HttpGet]
        [Route("get:all")]
        public async Task<PagedList<BookDto>> FilterAsync([FromQuery] BillboardFilter? filter)
        {
            var books = await _bookService.FilterAsync(filter);
            return PagedList<BookDto>.ToPagedList(books);
        }
    }
}
