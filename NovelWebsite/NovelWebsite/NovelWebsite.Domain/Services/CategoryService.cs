using AutoMapper;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Infrastructure.Repositories;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class CategoryService : ICategoryService
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
            return _mapper.Map<IEnumerable<CategoryEntity>, IEnumerable<CategoryModel>>(categories);
        }

        public void AddCategory(CategoryModel category)
        {
            _categoryRepository.Insert(_mapper.Map<CategoryModel, CategoryEntity>(category));
            _categoryRepository.Save();
        }

        public void UpdateCategory(CategoryModel category)
        {
            _categoryRepository.Update(_mapper.Map<CategoryModel, CategoryEntity>(category));
            _categoryRepository.Save();
        }

        public void RemoveCategory(int categoryId)
        {
            _categoryRepository.Delete(categoryId);
            _categoryRepository.Save();
        }

        public CategoryModel FindCategory(int categoryId){
            var category = _categoryRepository.GetById(categoryId);
            return _mapper.Map<CategoryEntity, CategoryModel>(category);
        }
    }
}