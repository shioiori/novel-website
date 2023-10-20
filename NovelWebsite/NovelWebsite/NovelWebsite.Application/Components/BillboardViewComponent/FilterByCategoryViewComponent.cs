using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.NovelWebsite.Application.Components.HomeViewComponent
{
    public class FilterByCategoryViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public FilterByCategoryViewComponent(ICategoryService categoryService)
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
