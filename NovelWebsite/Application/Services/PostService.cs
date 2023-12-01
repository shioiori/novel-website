using System.Linq.Expressions;
using NovelWebsite.Application.Models.Requests;
using NovelWebsite.Application.Utils;
using NovelWebsite.Application.Utils;
using NovelWebsite.Application.Models.Dtos;
using Application.Services.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Interfaces;
using AutoMapper;
using NovelWebsite.Application.Models.Filters;
using NovelWebsite.Application.Interfaces;

namespace NovelWebsite.Application.Services
{

    public class PostService : GenericService<Post, PostDto>, IPostService
    {
        public PostService(IPostRepository postRepository, IMapper mapper) : base(postRepository, mapper) { }

        public async Task<IEnumerable<PostDto>> FilterAsync(PostFilter filter, PagedListRequest request)
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
            var posts = PagedList<Post>.AsEnumerable(query, request);
            return await MapDtosAsync(posts);
        }
        public async Task<PostDto> GetByIdAsync(string postId)
        {
            var post = _repository.Get(x => x.PostId == postId).FirstOrDefault();
            return await MapDtoAsync(post);

        }
    }
}
