using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class CategoryService 
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoryModel> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(categories);
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
            return _mapper.Map<Category, CategoryModel>(category);
        }

        public CategoryModel GetCategory(string slug)
        {
            var category = _categoryRepository.GetByExpression(x => x.Slug == slug);
            return _mapper.Map<Category, CategoryModel>(category);
        }
    }
}