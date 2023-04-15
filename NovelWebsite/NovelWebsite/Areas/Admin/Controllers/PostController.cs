using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;
using NovelWebsite.Extensions;
using NovelWebsite.Models;
using System.Security.Claims;

namespace NovelWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Biên tập viên")]
    public class PostController : Controller
    {
        private readonly AppDbContext _dbContext;

        public PostController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index(string? name, int pageNumber = 1, int pageSize = 5)
        {
            var query = _dbContext.Posts.Where(p => p.IsDeleted == false)
                                        .Where(p => string.IsNullOrEmpty(name) || p.Title.ToLower().Trim().Contains(name.ToLower().Trim()))
                                        .Include(p => p.User)
                                        .OrderByDescending(p => p.CreatedDate);

            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.pageCount = Math.Ceiling(query.Count() * 1.0 / pageSize);
            ViewBag.searchName = name;

            return View(query.Skip(pageSize * pageNumber - pageSize)
                         .Take(pageSize)
                         .ToList());
        }

        [HttpGet]
        public IActionResult AddOrUpdatePost(int id = 0)
        {
            var post = _dbContext.Posts.Where(x => x.PostId == id)
                                       .Include(p => p.User)
                                       .FirstOrDefault();
            if (post == null)
            {
                try {
                    var claims = HttpContext.User.Identity as ClaimsIdentity;
                    var account = claims.FindFirst(ClaimTypes.NameIdentifier).Value;
                    post = new PostEntity()
                    {
                        UserId = _dbContext.Accounts.First(a => a.AccountName == account).UserId,
                        PostId = id,
                    };
                }
                catch (Exception ex) { };
            }
            return View(post);
        }

        [HttpPost]
        public IActionResult AddOrUpdatePost(PostModel postModel)
        {
            var post = _dbContext.Posts.FirstOrDefault(p => p.PostId == postModel.PostId);
            if (post == null)
            {
                post = new PostEntity()
                {
                    Title = postModel.Title,
                    Description = postModel.Description,
                    Content = StringExtension.HtmlEncode(postModel.Content),
                    Slug = StringExtension.Slugify(postModel.Title),
                    Views = 0,
                    Likes = 0,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Status = 0,
                    IsDeleted = false,
                    UserId = postModel.UserId,
                };
                _dbContext.Posts.Add(post);
            }
            else
            {
                post.Title = postModel.Title;
                post.Slug = StringExtension.Slugify(postModel.Title);
                post.Description = postModel.Description;
                post.Content = StringExtension.HtmlEncode(postModel.Content);
                post.UpdatedDate = DateTime.Now;
                _dbContext.Posts.Update(post);
            }
            _dbContext.SaveChanges();
            return Redirect($"/Admin/Post/Index");
        }

        public IActionResult DeletePost(int id)
        {
            var post = _dbContext.Posts.First(p => p.PostId == id);
            post.IsDeleted = true;
            _dbContext.Posts.Update(post);
            _dbContext.SaveChanges();
            return Redirect("/Admin/Post/Index");
        }
    }
}
