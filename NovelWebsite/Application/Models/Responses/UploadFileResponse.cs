using NovelWebsite.Application.Models.Response;

namespace NovelWebsite.Application.Models.Response
{
    public class UploadFileResponse : Response
    {
        public bool Success { get; set; }
        public string FileId { get; set; }
        public string UrlAccess { get; set; }
    }
}
