using AutoMapper;
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
            return _tagService.GetAllTags();
        }

        [HttpGet]
        [Route("get-by-id")]
        public TagModel GetById(int id)
        {
            return _tagService.GetTag(id);
        }

        [HttpPost]
        [Route("add")]
        public void Add(TagModel tag)
        {
            _tagService.AddTag(tag);
        }

        [HttpPost]
        [Route("update")]
        public void Update(TagModel tag)
        {
            _tagService.UpdateTag(tag);
        }

        [HttpPost]
        [Route("delete")]

        public void Delete(int tagId)
        {
            _tagService.RemoveTag(tagId);
        }
    }
}
