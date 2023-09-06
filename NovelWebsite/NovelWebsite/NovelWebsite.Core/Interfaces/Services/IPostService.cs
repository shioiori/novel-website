using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces
{
    public interface IPostService
    {
        void CreatePost(PostModel post);
        void DeletePost(int postId);
        IEnumerable<PostModel> GetListOfPosts(string name);
        IEnumerable<PostModel> GetListOfPublishedPosts(string name);
        PostModel GetPublishedPost(int postId);
        IEnumerable<PostModel> GetPublishedPosts();
        void UpdatePost(PostModel post);
    }
}
