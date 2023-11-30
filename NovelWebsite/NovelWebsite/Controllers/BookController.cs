
using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Filter;
using Application.Utils;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Controllers.Base;

namespace NovelWebsite.Controllers
{
    [ApiController]
    [Route("/book")]
    public class BookController : BaseController<BookDto>
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService) : base(bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            try
            {
                var book = await _bookService.GetByIdAsync(id);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get:all")]
        public async Task<IActionResult> FilterAsync([FromQuery] BookFilter? filter)
        {
            try
            {
                var books = await _bookService.FilterAsync(filter);
                return Ok(PagedList<BookDto>.ToPagedList(books));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
