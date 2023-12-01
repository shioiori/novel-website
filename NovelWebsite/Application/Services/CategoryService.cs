using AutoMapper;
using NovelWebsite.Application.Models.Requests;
using NovelWebsite.Application.Utils;
using NovelWebsite.Application.Models.Dtos;
using Application.Services.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Interfaces;
using NovelWebsite.Application.Interfaces;

namespace NovelWebsite.Application.Services
{
    public class CategoryService : GenericService<Category, CategoryDto>, ICategoryService
    {
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : base(categoryRepository, mapper) { }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync(PagedListRequest pagedListRequest)
        {
            var query = _repository.Get();
            var categories = PagedList<Category>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(categories);
        }

        public async Task<CategoryDto> GetByIdAsync(int categoryId)
        {
            var category = _repository.Get(x => x.CategoryId == categoryId).FirstOrDefault();
            return await MapDtoAsync(category);
        }
        public async Task<CategoryDto> GetByNameAsync(string name)
        {
            var category = _repository.Get(x => x.CategoryName == name).FirstOrDefault();
            return await MapDtoAsync(category);
        }
        public async Task<CategoryDto> GetBySlugAsync(string slug)
        {
            var category = _repository.Get(x => x.Slug == slug).FirstOrDefault();
            return await MapDtoAsync(category);
        }
    }
}