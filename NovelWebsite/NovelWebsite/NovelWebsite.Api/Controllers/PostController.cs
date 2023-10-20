﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [Route("/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [Route("get-by-filter")]
        [HttpGet]
        public IEnumerable<PostModel> GetByFilter(string? name, string? orderDate)
        {
            SortOrder ordDate = SortOrder.Descending;
            if (!string.IsNullOrEmpty(orderDate))
            {
                if (int.TryParse(orderDate, out int ord))
                {
                    ordDate = (SortOrder)ord;
                }
                else
                {
                    ordDate = (SortOrder)Enum.Parse(typeof(SortOrder), orderDate, true);
                }
            }
            IEnumerable<PostModel> posts;
            if (!string.IsNullOrEmpty(name))
            {
                posts = _postService.GetPublishedPosts(name);
            }
            else
            {
                posts = _postService.GetPublishedPosts();
            }
            switch (ordDate)
            {
                case SortOrder.Ascending:
                    posts = posts.OrderBy(x => x.CreatedDate);
                    break;
                case SortOrder.Descending:
                    posts = posts.OrderByDescending(x => x.CreatedDate);
                    break;
                default:
                    break;
            }
            return posts;
        }
    }
}
