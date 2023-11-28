namespace NovelWebsite.Application.Models.Request
{
    public class UploadRequest
    {
        public string Folder {  get; set; }
        public IFormFile File { get; set; }
    }
}
