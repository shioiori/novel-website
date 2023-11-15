using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Services
{
    public interface ITagService : IService<TagModel>
    {
        TagModel GetById(int id);
        TagModel GetTagBySlug(string slug);
        TagModel GetTagByName(string name);
        IEnumerable<TagModel> GetTagsOfBook(string bookId);
        void AddTagsOfBook(string bookId, IEnumerable<TagModel> tags);
    }
}
