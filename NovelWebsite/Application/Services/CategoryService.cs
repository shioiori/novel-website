using AutoMapper;
using NovelWebsite.Application.Models.Request;
using Application.Utils;
using Application.Models.Dtos;
using Application.Services.Base;
using NovelWebsite.Domain.Entities;

namespace NovelWebsite.Application.Services
{
    public class CategoryService : GenericService<Category, CategoryDto>
    {
        public CategoryService() : base() { }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(PagedListRequest pagedListRequest = null)
        {
            var query = _repository.Get();
            var categories = PagedList<Category>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(categories);
        }

        public async Task<CategoryDto> GetCategoryAsync(int categoryId){
            var category = _repository.Get(x => x.CategoryId == categoryId).FirstOrDefault();
            return await MapDtosAsync(category);
        }

        public async Task<CategoryDto> GetCategoryAsync(string slug)
        {
            var category = _repository.Get(x => x.Slug == slug).FirstOrDefault();
            return await MapDtosAsync(category);
        }
    }
}