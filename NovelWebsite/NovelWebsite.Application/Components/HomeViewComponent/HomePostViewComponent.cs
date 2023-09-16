using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.Application.Components.HomeViewComponent
{
    public class HomePostViewComponent : ViewComponent
    {
        private readonly IPostService _postService;

        public HomePostViewComponent(IPostService postService)
        {
            _postService = postService;
        }

        public IViewComponentResult Invoke(int number = 9)
        {
            var categories = _postService.GetPublishedPosts().Take(number);
            return View(categories);
        }
    }
}
