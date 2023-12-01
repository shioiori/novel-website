﻿using NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Models.Dtos;
using NovelWebsite.Application.Models.Filters;
using NovelWebsite.Application.Utils;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Application.Models.Requests;
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
