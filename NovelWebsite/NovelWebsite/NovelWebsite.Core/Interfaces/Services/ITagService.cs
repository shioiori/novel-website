using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Services
{
    public interface ITagService
    {
        void AddTag(TagModel tag);
        IEnumerable<TagModel> GetAllTags();
        void RemoveTag(int tagId);
        void UpdateTag(TagModel tag);
        TagModel GetTag(int tagId);
        TagModel GetTag(string slug);
    }
}
