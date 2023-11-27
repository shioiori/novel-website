using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Models;
using System.Collections.Generic;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models.Response;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class CategoryService 
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IBookRepository bookRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync(PagedListRequest pagedListRequest = null)
        {
            var query = _categoryRepository.GetAll();
            var categories = PagedList<Category>.AsEnumerable(query, pagedListRequest);
            var list = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(categories);
            foreach (var item in list)
            {
                item.Quantity = await _bookRepository.CountAsync(x => x.CategoryId == item.CategoryId);
            }
            return list;
        }

        public async Task AddCategoryAsync(CategoryModel category)
        {
            await _categoryRepository.InsertAsync(_mapper.Map<CategoryModel, Category>(category));
            _categoryRepository.SaveAsync();
        }

        public async Task UpdateCategoryAsync(CategoryModel category)
        {
            await _categoryRepository.UpdateAsync(_mapper.Map<CategoryModel, Category>(category));
            _categoryRepository.SaveAsync();
        }

        public async Task RemoveCategoryAsync(int categoryId)
        {
            await _categoryRepository.DeleteAsync(categoryId);
            _categoryRepository.SaveAsync();
        }

        public async Task<CategoryModel> GetCategoryAsync(int categoryId){
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            var model = _mapper.Map<Category, CategoryModel>(category);
            model.Quantity = await _bookRepository.CountAsync(x => x.CategoryId == model.CategoryId);
            return model;
        }

        public async Task<CategoryModel> GetCategoryAsync(string slug)
        {
            var category = await _categoryRepository.GetByExpressionAsync(x => x.Slug == slug);
            var model = _mapper.Map<Category, CategoryModel>(category);
            model.Quantity = await _bookRepository.CountAsync(x => x.CategoryId == model.CategoryId);
            return model;
        }
    }
}