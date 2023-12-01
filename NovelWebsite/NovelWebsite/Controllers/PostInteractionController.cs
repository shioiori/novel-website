using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Domain.Services;
using NovelWebsite.Controllers.Base;
using NovelWebsite.Application.Interfaces;

namespace NovelWebsite.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("/interact/post")]
    public class PostInteractionController : InteractionController
    {
        private readonly IPostInteractionService _postInteractionService;

        public PostInteractionController(IPostInteractionService postInteractionService) : base(postInteractionService) 
        {
            _postInteractionService = postInteractionService;
        }
    }
}
