using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.Application.Components.HomeViewComponent
{
    public class HomeCategoryViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IBookService _bookService;

        public HomeCategoryViewComponent(ICategoryService categoryService, IBookService bookService)
        {
            _categoryService = categoryService;
            _bookService = bookService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryService.GetAllCategories();
            foreach (var item in categories)
            {
                item.Quantity = _bookService.GetBooksByCategory(item.CategoryId).Count();
            }
            return View(categories);
        }
    }
}
