using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;
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
        [Consumes("multipart/form-data")]        
        
        public async Task<UploadFileResponse> UploadFileToCloud([FromForm] UploadRequest request)
        {
            using (var stream = request.File.OpenReadStream())
            {
                var fileName = Path.GetFileName(request.File.FileName);
                var response = await _uploadService.SaveFileCloud(stream, fileName, request.Folder);
                return response;
            }
        }
    }
}
