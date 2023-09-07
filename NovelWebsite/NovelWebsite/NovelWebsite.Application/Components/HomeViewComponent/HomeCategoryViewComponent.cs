using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.NovelWebsite.Application.Components.HomeViewComponent
{
    public class HomeCategoryViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public HomeCategoryViewComponent(ICategoryService categoryService)
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
