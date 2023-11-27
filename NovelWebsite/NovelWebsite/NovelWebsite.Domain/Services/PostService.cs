using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Models;
using System.Linq.Expressions;
using NovelWebsite.NovelWebsite.Core.Models.Response;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using NovelWebsite.NovelWebsite.Domain.Utils;
using System.Xml.Linq;

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

        public IEnumerable<PostModel> GetPublishedPosts(string name, PagedListRequest pagedListRequest = null)
        {
            var exp = ExpressionUtil<Post>.Combine(expContainString(name), expPublishedPost);
            var query = _postRepository.Filter(exp);
            var posts = PagedList<Post>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Post>, IEnumerable<PostModel>>(posts);
        }

        public IEnumerable<PostModel> GetPublishedPosts(PagedListRequest pagedListRequest = null)
        {
            var query = _postRepository.Filter(expPublishedPost);
            var posts = PagedList<Post>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Post>, IEnumerable<PostModel>>(posts);
        }

        public IEnumerable<PostModel> GetPosts(string name = null, PagedListRequest pagedListRequest = null)
        {
            var query = _postRepository.Filter(expContainString(name));
            var posts = PagedList<Post>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Post>, IEnumerable<PostModel>>(posts);
        }

        public async Task<PostModel> GetPostAsync(string postId)
        {
            var post = await _postRepository.GetByExpressionAsync(x => x.PostId == postId);
            return _mapper.Map<Post, PostModel>(post);
        }

        public async Task CreatePostAsync(PostModel post)
        {
            await _postRepository.InsertAsync(_mapper.Map<PostModel, Post>(post));
            _postRepository.SaveAsync();
        }

        public async Task UpdatePostAsync(PostModel post)
        {
            await _postRepository.UpdateAsync(_mapper.Map<PostModel, Post>(post));
            _postRepository.SaveAsync();
        }

        public async Task DeletePostAsync(string postId)
        {
            await _postRepository.DeleteAsync(postId);
            _postRepository.SaveAsync();
        }
    }
}
