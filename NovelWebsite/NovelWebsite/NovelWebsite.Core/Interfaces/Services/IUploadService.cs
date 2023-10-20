using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces
{
    public interface IUploadService
    {
        Task<UploadFileResponse> SaveFileCloud(Stream stream, string fileName, string folder);
        UploadFileResponse SaveFileLocal(IFormFile file, string folder);
    }
}
