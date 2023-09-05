using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces
{
    public interface IPostService
    {
        void CreatePost(PostModel post);
        void DeletePost(int postId);
        IEnumerable<PostModel> GetListOfPosts(string name);
        IEnumerable<PostModel> GetListOfValidPosts(string name);
        PostModel GetValidPost(int postId);
        IEnumerable<PostModel> GetValidPosts();
        void UpdatePost(PostModel post);
    }
}
