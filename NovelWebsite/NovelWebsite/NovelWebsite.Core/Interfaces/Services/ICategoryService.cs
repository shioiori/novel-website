using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    
    public interface ICategoryService
    {
        void AddCategory(CategoryModel category);
        IEnumerable<CategoryModel> GetAllCategories();
        void RemoveCategory(int categoryId);
        void UpdateCategory(CategoryModel category);
        CategoryModel GetCategory(int categoryId);
        CategoryModel GetCategory(string slug);

    }

}