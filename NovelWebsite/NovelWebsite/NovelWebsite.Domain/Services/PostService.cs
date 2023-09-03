using AutoMapper;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Models;
using System.Linq.Expressions;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        Expression<Func<Post, bool>> expValidPost = p => p.Status == 0 && p.IsDeleted == false;
        Expression<Func<Post, bool>> expContainString(string name){
            return x => string.IsNullOrEmpty(name)
                    || x.Title.Trim().ToLower().Contains(name.Trim().ToLower())
                    || x.Content.Trim().ToLower().Contains(name.Trim().ToLower());
        }

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public IEnumerable<PostModel> GetListOfValidPosts(string? name)
        {
            var posts = _postRepository.Filter(expContainString(name)).Where(expValidPost.Compile());
            return _mapper.Map<IEnumerable<Post>, IEnumerable<PostModel>>(posts);
        }

        public IEnumerable<PostModel> GetValidPosts()
        {
            var posts = _postRepository.Filter(expValidPost);
            return _mapper.Map<IEnumerable<Post>, IEnumerable<PostModel>>(posts);
        }

        public PostModel GetValidPost(int postId)
        {
            var post = _postRepository.Filter(expValidPost).FirstOrDefault(x => x.PostId == postId);
            return _mapper.Map<Post, PostModel>(post);
        }

        public IEnumerable<PostModel> GetListOfPosts(string? name)
        {
             var posts = _postRepository.Filter(expContainString(name));
            return _mapper.Map<IEnumerable<Post>, IEnumerable<PostModel>>(posts);
        }
    }
}
