namespace NovelWebsite.NovelWebsite.Core.Models.Request
{
    public class UploadRequest
    {
        public string Folder {  get; set; }
        public IFormFile File { get; set; }
    }
}
