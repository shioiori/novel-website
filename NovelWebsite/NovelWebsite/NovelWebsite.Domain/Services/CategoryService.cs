using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Models;
using System.Collections.Generic;

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

        public IEnumerable<CategoryModel> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            var list = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(categories);
            foreach (var item in list)
            {
                item.Quantity = _bookRepository.Filter(x => x.CategoryId == item.CategoryId).Count();
            }
            return list;
        }

        public void AddCategory(CategoryModel category)
        {
            _categoryRepository.Insert(_mapper.Map<CategoryModel, Category>(category));
            _categoryRepository.Save();
        }

        public void UpdateCategory(CategoryModel category)
        {
            _categoryRepository.Update(_mapper.Map<CategoryModel, Category>(category));
            _categoryRepository.Save();
        }

        public void RemoveCategory(int categoryId)
        {
            _categoryRepository.Delete(categoryId);
            _categoryRepository.Save();
        }

        public CategoryModel GetCategory(int categoryId){
            var category = _categoryRepository.GetById(categoryId);
            var model = _mapper.Map<Category, CategoryModel>(category);
            model.Quantity = _bookRepository.Filter(x => x.CategoryId == model.CategoryId).Count();
            return model;
        }

        public CategoryModel GetCategory(string slug)
        {
            var category = _categoryRepository.GetByExpression(x => x.Slug == slug);
            var model = _mapper.Map<Category, CategoryModel>(category);
            model.Quantity = _bookRepository.Filter(x => x.CategoryId == model.CategoryId).Count();
            return model;
        }
    }
}