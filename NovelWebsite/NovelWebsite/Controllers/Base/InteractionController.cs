using NovelWebsite.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Domain.Enums;
using System.Security.Claims;
using HttpClient = System.Web.Http;

namespace NovelWebsite.Controllers.Base
{
    public class InteractionController : ControllerBase
    {
        private readonly IInteractionService _interactionService;

        public InteractionController(IInteractionService interactionService)
        {
            _interactionService = interactionService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAsync(string? userId, string bookId, InteractionType type)
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                }
                return Ok(await _interactionService.IsInteractionEnabledAsync(bookId, userId, type));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("set")]
        public async Task<IActionResult> SetAsync(string? userId, string bookId, InteractionType type)
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                }
                return Ok(await _interactionService.SetStatusOfInteractionAsync(bookId, userId, type));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
