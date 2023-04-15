using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;

namespace NovelWebsite.Controllers
{
    [Route("/tac-gia")]
    public class AuthorController : Controller
    {
        private readonly AppDbContext _dbContext;

        public AuthorController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Route("{authorId}/{slug}")]
        public IActionResult Index(int authorId)
        {
            var query = _dbContext.Books.Where(b => b.IsDeleted == false && b.AuthorId == authorId)
                                        .Include(b => b.Author)
                                        .Include(b => b.Category)
                                        .Include(b => b.User)
                                        .Include(b => b.BookStatus)
                                        .OrderByDescending(b => b.CreatedDate)
                                        .ToList();
            ViewBag.Author = _dbContext.Authors.FirstOrDefault(x => x.AuthorId == authorId).AuthorName;
            return View(query);
        }
    }
}
