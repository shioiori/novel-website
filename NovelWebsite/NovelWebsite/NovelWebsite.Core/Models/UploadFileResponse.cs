namespace NovelWebsite.NovelWebsite.Core.Models
{
    public class UploadFileResponse : BaseResponse
    {
        public string FileId { get; set; }
        public string UrlAccess { get; set; }
    }
}
