using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Infrastructure.Contexts;

namespace NovelWebsite.NovelWebsite.Application.Admin.Controllers
{
    public class ImageController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;

        public ImageController(AppDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile file, string folder)
        {
            if (file == null)
            {
                return Json(new { status = "error" });
            }
            string folderUploads = Path.Combine(_environment.WebRootPath, $"image\\{folder}");

            bool exists = Directory.Exists(folderUploads);
            if (!exists)
                Directory.CreateDirectory(folderUploads);
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string fullPath = Path.Combine(folderUploads, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return Json($"/image/{folder}/{fileName}");
        }
    }
}
