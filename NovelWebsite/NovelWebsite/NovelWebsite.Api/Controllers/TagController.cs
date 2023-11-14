using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.Api.Controllers
{
    [ApiController]
    [Route("/tag")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        [Route("get-all")]
        public IEnumerable<TagModel> GetAll()
        {
            return _tagService.GetAll();
        }

        [HttpGet]
        [Route("get-by-id")]
        public TagModel GetById(int id)
        {
            return _tagService.GetById(id);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("add")]
        public void Add(TagModel tag)
        {
            _tagService.Add(tag);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("update")]
        public void Update(TagModel tag)
        {
            _tagService.Update(tag);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("delete")]

        public void Delete(TagModel tag)
        {
            _tagService.Delete(tag);
        }
    }
}
