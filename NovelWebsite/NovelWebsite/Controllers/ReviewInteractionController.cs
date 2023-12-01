using NovelWebsite.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Controllers.Base;
using NovelWebsite.Domain.Services;

namespace NovelWebsite.Controllers
{

    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("/interact/review")]
    public class ReviewInteractionController : InteractionController
    {
        private readonly IReviewInteractionService _reviewInteractionService;

        public ReviewInteractionController(IReviewInteractionService reviewInteractionService) : base(reviewInteractionService) 
        {
            _reviewInteractionService = reviewInteractionService;
        }
    }
}
