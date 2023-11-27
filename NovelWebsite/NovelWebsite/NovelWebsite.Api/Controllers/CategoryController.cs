using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models.Response;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.Api.Controllers
{
    [ApiController]
    [Route("/category")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<PagedList<CategoryModel>> GetAllAsync([FromQuery] PagedListRequest request)
        {
            var categories = await _categoryService.GetAllCategoriesAsync(request);
            return PagedList<CategoryModel>.ToPagedList(categories);
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<CategoryModel> GetByIdAsync(int id)
        {
            return await _categoryService.GetCategoryAsync(id);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("add")]
        public void Add(CategoryModel category)
        {
            _categoryService.AddCategoryAsync(category);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("update")]
        public void Update(CategoryModel category)
        {
            _categoryService.UpdateCategoryAsync(category);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        [Route("delete")]
        public void Delete(int id)
        {
            _categoryService.RemoveCategoryAsync(id);
        }
    }
}
