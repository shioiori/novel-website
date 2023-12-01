using NovelWebsite.Application.Models.Responses;

namespace NovelWebsite.Application.Models.Responses
{
    public class UploadFileResponse : Response
    {
        public bool Success { get; set; }
        public string FileId { get; set; }
        public string UrlAccess { get; set; }
    }
}
