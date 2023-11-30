using System.Linq.Expressions;
using NovelWebsite.Application.Models.Request;
using NovelWebsite.Application.Utils;
using Application.Utils;
using Application.Models.Dtos;
using Application.Services.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Interfaces;
using AutoMapper;
using Application.Models.Filter;
using Application.Interfaces;

namespace NovelWebsite.Application.Services
{

    public class PostService : GenericService<Post, PostDto>, IPostService
    {
        public PostService(IPostRepository postRepository, IMapper mapper) : base(postRepository, mapper) { }

        public async Task<IEnumerable<PostDto>> FilterAsync(PostFilter filter)
        {
            var query = _repository.Get();
            if (filter == null)
            {
                return await MapDtosAsync(query.AsEnumerable());
            }
            if (filter.SearchName != null)
            {
                query = query.Where(x => x.Title.Trim().ToLower().Contains(filter.SearchName.Trim().ToLower()));
            }
            if (filter.UploadStatus != null)
            {
                query = query.Where(x => x.Status == (int)filter.UploadStatus);
            }
            var posts = PagedList<Post>.AsEnumerable(query, filter.PagedListRequest);
            return await MapDtosAsync(posts);
        }
        public async Task<PostDto> GetByIdAsync(string postId)
        {
            var post = _repository.Get(x => x.PostId == postId).FirstOrDefault();
            return await MapDtoAsync(post);

        }
    }
}
