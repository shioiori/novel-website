using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Application.Interfaces;
using NovelWebsite.Controllers.Base;

namespace NovelWebsite.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("/interact/comment")]
    public class CommentInteractionController : InteractionController
    {
        private readonly ICommentInteractionService _commentInteractionService;

        public CommentInteractionController(ICommentInteractionService commentInteractionService) : base(commentInteractionService)
        {
            _commentInteractionService = commentInteractionService;
        }
    }
}
