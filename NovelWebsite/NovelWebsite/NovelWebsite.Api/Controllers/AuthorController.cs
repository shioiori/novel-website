using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.Api.Controllers
{
    [ApiController]
    [Route("/author")]
    public class AuthorController : ControllerBase
    {
        private readonly IBookService _bookservice;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IBookService bookservice, IAuthorService authorService, IMapper mapper)
        {
            _bookservice = bookservice;
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("add")]
        public void Add(AuthorModel author)
        {
            _authorService.CreateAuthor(author);
        }

        [HttpPost]
        [Route("update")]
        public void Update(AuthorModel author)
        {
            _authorService.UpdateAuthor(author);
        }

        [HttpPost]
        [Route("delete")]

        public void Delete(int authorId)
        {
            _authorService.DeleteAuthor(authorId);
        }
    }
}
