using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Models;
using System.Linq.Expressions;

namespace NovelWebsite.NovelWebsite.Domain.Services
{

    public class PostService
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        Expression<Func<Post, bool>> expPublishedPost = p => p.Status == (int)UploadStatus.Publish;
        Expression<Func<Post, bool>> expContainString(string name)
        {
            return x => string.IsNullOrEmpty(name)
                    || x.Title.Trim().ToLower().Contains(name.Trim().ToLower())
                    || x.Content.Trim().ToLower().Contains(name.Trim().ToLower());
        }

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public IEnumerable<PostModel> GetPublishedPosts(string name)
        {
            var posts = _postRepository.Filter(expContainString(name)).Where(expPublishedPost.Compile());
            return _mapper.Map<IEnumerable<Post>, IEnumerable<PostModel>>(posts);
        }

        public IEnumerable<PostModel> GetPublishedPosts()
        {
            var posts = _postRepository.Filter(expPublishedPost);
            return _mapper.Map<IEnumerable<Post>, IEnumerable<PostModel>>(posts);
        }

        public PostModel GetPublishedPost(string postId)
        {
            var post = _postRepository.Filter(expPublishedPost).FirstOrDefault(x => x.PostId == postId);
            return _mapper.Map<Post, PostModel>(post);
        }

        public IEnumerable<PostModel> GetPosts(string name)
        {
            var posts = _postRepository.Filter(expContainString(name));
            return _mapper.Map<IEnumerable<Post>, IEnumerable<PostModel>>(posts);
        }

        public void CreatePost(PostModel post)
        {
            _postRepository.Insert(_mapper.Map<PostModel, Post>(post));
            _postRepository.Save();
        }

        public void UpdatePost(PostModel post)
        {
            _postRepository.Update(_mapper.Map<PostModel, Post>(post));
            _postRepository.Save();
        }

        public void DeletePost(string postId)
        {
            _postRepository.Delete(postId);
            _postRepository.Save();
        }
    }
}
