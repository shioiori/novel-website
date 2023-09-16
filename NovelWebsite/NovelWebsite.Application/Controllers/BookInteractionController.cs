using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.Application.Controllers
{
    [ApiController]
    [Route("/interact/book")]
    public class BookInteractionController : ControllerBase
    {
        private readonly BookInteractionService _bookInteractionService;
        private readonly IUserService _userService;

        public BookInteractionController(BookInteractionService bookInteractionService, IUserService userService)
        {
            _bookInteractionService = bookInteractionService;
            _userService = userService;
        }


        [Route("is-liked")]
        [HttpGet]
        public bool IsBookLiked(int bookId)
        {
            var user = _userService.GetCurrentUser();
            return _bookInteractionService.IsInteractionEnabled(bookId, user.UserId, InteractionType.Like);
        }

        [Route("is-recommended")]
        [HttpGet]
        public bool IsBookRecommended(int bookId)
        {
            var user = _userService.GetCurrentUser();
            return _bookInteractionService.IsInteractionEnabled(bookId, user.UserId, InteractionType.Recommend);
        }

        [Route("is-followed")]
        [HttpGet]
        public bool IsBookFollowed(int bookId)
        {
            var user = _userService.GetCurrentUser();
            return _bookInteractionService.IsInteractionEnabled(bookId, user.UserId, InteractionType.Follow);
        }

        [HttpGet]
        [Route("set-status-like")]

        public bool SetBookLike(int bookId)
        {
            var user = _userService.GetCurrentUser();
            return _bookInteractionService.SetStatusOfInteraction(bookId, user.UserId, InteractionType.Like);
        }

        [HttpGet]
        [Route("set-status-recommend")]

        public bool SetBookRecommend(int bookId)
        {
            var user = _userService.GetCurrentUser();
            return _bookInteractionService.SetStatusOfInteraction(bookId, user.UserId, InteractionType.Recommend);
        }

        [HttpGet]
        [Route("set-status-follow")]
        public bool SetBookFollow(int bookId)
        {
            var user = _userService.GetCurrentUser();
            return _bookInteractionService.SetStatusOfInteraction(bookId, user.UserId, InteractionType.Follow);
        }
    }
}
