using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.Application.Controllers
{
    [Route("/tin-tuc")]
    [Route("/{controller}")]
    public class PostController : Controller
    {
        private readonly IPostService _service;

        Expression<Func<PostModel, object>> expOrderByCreatedDate = p => p.CreatedDate; 
        public PostController(IPostService service)
        {
            _service = service;
        }

        [Route("")]
        [Route("{action}")]

        public IActionResult ListOfPosts(int sortOrder, string? name, int pageNumber = 1, int pageSize = 10)
        {
            var posts = _service.GetListOfValidPosts(name);
            switch ((SortOrder)sortOrder)
            {
                case SortOrder.Ascending:
                    posts.OrderBy(expOrderByCreatedDate.Compile());
                    break;
                case SortOrder.Descending:
                    posts.OrderByDescending(expOrderByCreatedDate.Compile());
                    break;
                default:
                    break;
            }

            // ViewBag.pageNumber = pageNumber;
            // ViewBag.pageSize = pageSize;
            // ViewBag.pageCount = Math.Ceiling(query.Count() * 1.0 / pageSize);
            // ViewBag.searchName = name;
            // ViewBag.sortBy = sort_by;

            // return View(query.Skip(pageSize * pageNumber - pageSize)
            //              .Take(pageSize)
            //              .ToList());
            return View(posts);
        }

        [Route("{slug}-{id:int}")]
        [Route("{action}")]

        public IActionResult Index(int id)
        {
            var post = _service.GetValidPost(id);
            return View(post);
        }

        // [Route("{action}")]
        // public IActionResult GetListComments(int id)
        // {
        //     var listComment = _dbContext.Comments.Where(c => c.PostId == id).Include(p => p.User).OrderByDescending(c => c.CreatedDate).ToList();
        //     return Json(listComment);
        // }
    }
}
