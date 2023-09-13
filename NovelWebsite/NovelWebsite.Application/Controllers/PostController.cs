using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Domain.Services;
using X.PagedList;

namespace NovelWebsite.Application.Controllers
{
    [Route("/tin-tuc")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [Route("")]
        public IActionResult Index(string name, int sort_order = (int)SortOrder.Descending)
        {
            var posts = _postService.GetPublishedPosts(name);
            switch (sort_order)
            {
                case (int)SortOrder.Ascending:
                    posts = posts.OrderBy(x => x.CreatedDate);
                    break;
                case (int)SortOrder.Descending:
                    posts = posts.OrderByDescending(x => x.CreatedDate);
                    break;
                default: 
                    break;
            }
            return View(posts);
        }

    }
}
