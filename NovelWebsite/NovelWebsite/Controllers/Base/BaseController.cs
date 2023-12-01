using NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Models.Dtos;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Services;

namespace NovelWebsite.Controllers.Base
{
    public class BaseController<TDto> : ControllerBase
    {
        protected readonly IService<TDto> _service;

        public BaseController(IService<TDto> service)
        {
            _service = service;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync(TDto dto)
        {
            try
            {
                var res = await _service.AddAsync(dto);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync(TDto dto)
        {
            try
            {
                var res = _service.UpdateAsync(dto);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        [Route("delete")]

        public async Task<IActionResult> DeleteAsync(object dtoId)
        {
            try
            {
                await _service.DeleteAsync(dtoId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
