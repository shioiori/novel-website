using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.NovelWebsite.Application.Components.HomeViewComponent
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryService.GetAllCategories();
            return View(categories);
        }
    }
}
