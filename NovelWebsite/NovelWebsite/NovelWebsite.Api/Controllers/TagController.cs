using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models.Response;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.Api.Controllers
{
    [ApiController]
    [Route("/tag")]
    public class TagController : ControllerBase
    {
        private readonly TagService _tagService;

        public TagController(TagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        [Route("get-all")]
        public PagedList<TagModel> GetAll([FromQuery] PagedListRequest request)
        {
            var tags = _tagService.GetAll(request);
		    return PagedList<TagModel>.ToPagedList(tags);
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<TagModel> GetByIdAsync(int id)
        {
            return await _tagService.GetByIdAsync(id);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("add")]
        public void Add(TagModel tag)
        {
            _tagService.AddAsync(tag);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("update")]
        public void Update(TagModel tag)
        {
            _tagService.UpdateAsync(tag);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        [Route("delete")]

        public void Delete(string tag)
        {
            _tagService.DeleteAsync(tag);
        }
    }
}
