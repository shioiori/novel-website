using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("/upload")]
    public class UploadController : ControllerBase
    {
        private readonly UploadService _uploadService;

        public UploadController(UploadService uploadService) 
        { 
            _uploadService = uploadService;
        }
        [HttpPost]
        [Route("file/cloud")]        
        
        public async Task<UploadFileResponse> UploadFileToCloud(string folder, IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                var fileName = Path.GetFileName(file.FileName);
                var response = await _uploadService.SaveFileCloud(stream, fileName, folder);
                return response;
            }
        }
    }
}
