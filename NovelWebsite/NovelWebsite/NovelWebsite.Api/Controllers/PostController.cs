using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models.Response;
using NovelWebsite.NovelWebsite.Domain.Services;
using System.Security.Claims;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [Route("/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }

        [Route("get-by-filter")]
        [HttpGet]
        public PagedList<PostModel> GetByFilter(string name, string sortOrder, [FromQuery] PagedListRequest request)
        {
            SortOrder ordDate = SortOrder.Descending;
            if (!string.IsNullOrEmpty(sortOrder))
            {
                if (int.TryParse(sortOrder, out int ord))
                {
                    ordDate = (SortOrder)ord;
                }
                else
                {
                    ordDate = (SortOrder)Enum.Parse(typeof(SortOrder), sortOrder, true);
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
            return PagedList<PostModel>.ToPagedList(posts, request);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("add")]
        public IActionResult Add(PostModel post)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                post.UserId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                _postService.CreatePost(post);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("update")]
        public IActionResult Update(PostModel post)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                post.UserId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                _postService.UpdatePost(post);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("delete")]
        public IActionResult Delete(string postId)
        {
            try
            {
                _postService.DeletePost(postId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
