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
        public PagedList<CategoryModel> GetAll([FromQuery] PagedListRequest request)
        {
            return PagedList<CategoryModel>.ToPagedList(_categoryService.GetAllCategories(), request);
        }

        [HttpGet]
        [Route("get-by-id")]
        public CategoryModel GetById(int id)
        {
            return _categoryService.GetCategory(id);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("add")]
        public void Add(CategoryModel category)
        {
            _categoryService.AddCategory(category);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("update")]
        public void Update(CategoryModel category)
        {
            _categoryService.UpdateCategory(category);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        [Route("delete")]

        public void Delete(int id)
        {
            _categoryService.RemoveCategory(id);
        }
    }
}
