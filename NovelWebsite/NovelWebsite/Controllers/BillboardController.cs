using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Filter;
using Application.Utils;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Application.Models.Request;
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
        [Route("")]
        public async Task<PagedList<BookDto>> FilterAsync([FromQuery] BillboardFilter? filter, [FromQuery] PagedListRequest? request)
        {
            var books = await _bookService.FilterAsync(filter, request);
            return PagedList<BookDto>.ToPagedList(books);
        }
    }
}
