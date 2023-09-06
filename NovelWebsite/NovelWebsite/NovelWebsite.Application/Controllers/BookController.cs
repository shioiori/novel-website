using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;

namespace NovelWebsite.Application.Controllers
{
    [Route("/truyen")]
    [Route("/{controller}")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public BookController(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }


        [Route("tac-gia/{slug}")]
        public IActionResult ListBooksOfAuthor(string slug)
        {
            var author = _authorService.GetAuthorBySlug(slug);
            //var books = _bookService.GetValidBooksByAuthor(author.AuthorId);
            return View(author);
        }

    }
}
