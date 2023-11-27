using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Domain.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.Api.Controllers
{
    [ApiController]
    [Route("/author")]
    public class AuthorController : ControllerBase
    {
        private readonly BookService _bookservice;
        private readonly AuthorService _authorService;

        public AuthorController(BookService bookservice, AuthorService authorService)
        {
            _bookservice = bookservice;
            _authorService = authorService;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("add")]
        public void Add(AuthorModel author)
        {
            _authorService.CreateAuthorAsync(author);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("update")]
        public void Update(AuthorModel author)
        {
            _authorService.UpdateAuthorAsync(author);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("delete")]

        public void Delete(int authorId)
        {
            _authorService.DeleteAuthorAsync(authorId);
        }
    }
}
