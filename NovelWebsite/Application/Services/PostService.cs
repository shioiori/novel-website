using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.Application.Enums;
using NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Interfaces.Repositories;
using System.Linq.Expressions;
using NovelWebsite.Application.Models.Request;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using NovelWebsite.Application.Utils;
using System.Xml.Linq;
using Application.Utils;
using Application.Models.Dtos;
using Application.Services.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Enums;

namespace NovelWebsite.Application.Services
{

    public class PostService : GenericService<Post, PostDto>
    {
        Expression<Func<Post, bool>> expPublishedPost = p => p.Status == (int)UploadStatus.Publish;
        Expression<Func<Post, bool>> expContainString(string name)
        {
            return x => string.IsNullOrEmpty(name)
                    || x.Title.Trim().ToLower().Contains(name.Trim().ToLower())
                    || x.Content.Trim().ToLower().Contains(name.Trim().ToLower());
        }

        public PostService() : base() { }

        public async Task<IEnumerable<PostDto>> GetPublishedPostsAsync(string name, PagedListRequest pagedListRequest = null)
        {
            var exp = ExpressionCombine<Post>.And(expContainString(name), expPublishedPost);
            var query = _repository.Get(exp);
            var posts = PagedList<Post>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(posts);
        }

        public async Task<IEnumerable<PostDto>> GetPublishedPostsAsync(PagedListRequest pagedListRequest = null)
        {
            var query = _repository.Get(expPublishedPost);
            var posts = PagedList<Post>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(posts);
        }

        public async Task<IEnumerable<PostDto>> GetPostsAsync(string name = null, PagedListRequest pagedListRequest = null)
        {
            var query = _repository.Get(expContainString(name));
            var posts = PagedList<Post>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(posts);
        }

        public async Task<PostDto> GetPostAsync(string postId)
        {
            var post = _repository.Get(x => x.PostId == postId).FirstOrDefault();
            return await MapDtosAsync(post);

        }
    }
}
