using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;

namespace NovelWebsite.Controllers
{
    [Route("/tin-tuc")]
    [Route("/{controller}")]
    public class PostController : Controller
    {
        private readonly AppDbContext _dbContext;

        public PostController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("")]
        [Route("{action}")]

        public IActionResult ListOfPosts(string? sort_by, string? name, int pageNumber = 1, int pageSize = 10)
        {
            var query = _dbContext.Posts.Where(p => string.IsNullOrEmpty(name) || p.Title.ToLower().Trim().Contains(name.ToLower().Trim()))
                                           .Include(b => b.User)
                                           .OrderByDescending(r => r.CreatedDate);
            if (string.IsNullOrEmpty(sort_by))
            {
                if (sort_by == "up")
                {
                    query = query.OrderBy(p => p.CreatedDate);
                }
            }
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.pageCount = Math.Ceiling(query.Count() * 1.0 / pageSize);
            ViewBag.searchName = name;
            ViewBag.sortBy = sort_by;
         
            return View(query.Skip(pageSize * pageNumber - pageSize)
                         .Take(pageSize)
                         .ToList());
        }

        [Route("{slug}-{id:int}")]
        [Route("{action}")]

        public IActionResult Index(int id)
        {
            var post = _dbContext.Posts.Where(p => p.Status == 0 && p.IsDeleted == false && p.PostId == id)
                                       .Include(p => p.User)
                                       .FirstOrDefault();
            return View(post);
        }

        [Route("{action}")]
        public IActionResult GetListComments(int id)
        {
            var listComment = _dbContext.Comments.Where(c => c.PostId == id).Include(p => p.User).OrderByDescending(c => c.CreatedDate).ToList();
            return Json(listComment);
        }
    }
}
