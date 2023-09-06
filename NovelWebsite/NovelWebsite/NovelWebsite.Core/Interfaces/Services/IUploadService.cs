namespace NovelWebsite.NovelWebsite.Core.Interfaces
{
    public interface IUploadService
    {
        string SaveFileCloud(IFormFile file);
        string SaveFileLocal(IFormFile file, string folder);
    }
}
