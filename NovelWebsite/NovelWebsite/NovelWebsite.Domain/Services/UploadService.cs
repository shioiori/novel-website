using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Models;
using System.IO;

namespace NovelWebsite.NovelWebsite.Domain.Services
{

    public class UploadService
    {
        private readonly IWebHostEnvironment _environment;

        private readonly IConfiguration _configuration;
        public UploadService(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }

        public UploadFileResponse SaveFileLocal(IFormFile file, string folder)
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
            return new UploadFileResponse();
        }

        public async Task<UploadFileResponse> SaveFileCloud(Stream fileStream, string fileName, string folder)
        {
            try
            {
                var credential = GoogleCredential.FromFile(_configuration.GetValue<string>("FileStorage:GoogleCredentialFile"))
                                                 .CreateScoped(DriveService.ScopeConstants.Drive);
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential
                });
                var fileUpload = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = fileName + Guid.NewGuid().ToString(),
                    Parents = new[] { folder }
                };
                // Create a new file on Google Drive
                using (var stream = fileStream)
                {
                    // Create a new file, with metadata and stream.
                    var request = service.Files.Create(fileUpload, stream, Path.GetExtension(fileName));
                    request.Fields = "id";
                    var results = await request.UploadAsync();
                    var uploadedFile = request.ResponseBody;
                    return new UploadFileResponse()
                    {
                        Success = true,
                        Message = "Upload thành công",
                        FileId = uploadedFile.Id,
                        UrlAccess = $"https://drive.google.com/file/{folder}/{uploadedFile.Id}"
                    };
                }

            }
            catch (Exception ex)
            {
                return new UploadFileResponse()
                {
                    Success = false,
                    Message = "Upload thất bại",
                };
                throw;
            }
        }
    }
}
