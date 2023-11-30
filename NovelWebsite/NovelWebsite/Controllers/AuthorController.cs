using Application.Interfaces;
using Application.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Application.Models.Request;
using NovelWebsite.Application.Services;
using NovelWebsite.Controllers.Base;

namespace NovelWebsite.Controllers
{
    [ApiController]
    [Route("/author")]
    public class AuthorController : BaseController<AuthorDto>
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService) : base(authorService) 
        {
            _authorService = authorService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync([FromQuery] PagedListRequest? request) {
            try
            {
                var authors = await _authorService.GetAllAsync(request);
                return Ok(authors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var authors = await _authorService.GetByIdAsync(id);
                return Ok(authors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
