using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Application.Interfaces;
using NovelWebsite.Controllers.Base;
using HttpClient = System.Web.Http;

namespace NovelWebsite.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("/interact/book")]
    public class BookInteractionController : InteractionController
    {
        private readonly IBookInteractionService _bookInteractionService;

        public BookInteractionController(IBookInteractionService bookInteractionService) : base(bookInteractionService) 
        {
            _bookInteractionService = bookInteractionService;
        }

        [HttpPut("mark")]
        public async Task<IActionResult> MarkAsync(string? userId, string bookId, string chapterId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                }
                await _bookInteractionService.MarkAsync(bookId, userId, chapterId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
