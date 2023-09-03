using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;

namespace NovelWebsite.Application.Controllers
{
    [Route("/tac-gia")]
    public class AuthorController : Controller
    {
        private readonly IBookService _service;

        public AuthorController(IBookService service)
        {
            _service = service;
        }
        
        [Route("{authorId}/{slug?}")]
        public IActionResult Index(int authorId)
        {
        }
    }
}
