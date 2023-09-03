using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces
{
    public interface IPostService
    {
        PostModel GetValidPost(int postId);
        IEnumerable<PostModel> GetValidPosts();
        IEnumerable<PostModel> GetListOfValidPosts(string? name);
        IEnumerable<PostModel> GetListOfPosts(string? name);

    }
}
