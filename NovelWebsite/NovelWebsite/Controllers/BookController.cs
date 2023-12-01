
using NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Models.Dtos;
using NovelWebsite.Application.Models.Filters;
using NovelWebsite.Application.Utils;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Application.Models.Requests;
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

        [HttpGet("{id}")]
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

        [HttpGet("")]
        public async Task<IActionResult> FilterAsync([FromQuery] BookFilter? filter, [FromQuery] PagedListRequest? request)
        {
            try
            {
                var books = await _bookService.FilterAsync(filter, request);
                return Ok(PagedList<BookDto>.ToPagedList(books));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
