using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Interfaces;

namespace NovelWebsite.NovelWebsite.Domain.Services
{

    public class UploadService : IUploadService
    {
        private readonly IWebHostEnvironment _environment;
        public UploadService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public string SaveFileLocal(IFormFile file, string folder)
        {
            string folderUploads = Path.Combine(_environment.WebRootPath, $"image\\{folder}");

            bool exists = System.IO.Directory.Exists(folderUploads);
            if (!exists)
                System.IO.Directory.CreateDirectory(folderUploads);
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string fullPath = Path.Combine(folderUploads, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return fullPath;
        }

        public string SaveFileCloud(IFormFile file)
        {
            return "nah";
        }
    }
}
