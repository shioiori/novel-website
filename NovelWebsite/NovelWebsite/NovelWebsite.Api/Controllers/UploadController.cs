using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [ApiController]
    [Route("/upload")]
    public class UploadController : ControllerBase
    {
        private readonly IUploadService _uploadService;

        public UploadController(IUploadService uploadService) 
        { 
            _uploadService = uploadService;
        }
        [HttpPost]
        [Route("file/cloud")]        
        
        public async Task<UploadFileResponse> UploadFileToCloud(IFormFile file, string folder)
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
