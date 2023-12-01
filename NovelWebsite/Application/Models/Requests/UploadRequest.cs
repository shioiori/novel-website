using Microsoft.AspNetCore.Http;

namespace NovelWebsite.Application.Models.Requests
{
    public class UploadRequest
    {
        public string Folder {  get; set; }
        public IFormFile File { get; set; }
    }
}
