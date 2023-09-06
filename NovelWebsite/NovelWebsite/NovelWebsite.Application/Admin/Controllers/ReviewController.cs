using Microsoft.AspNetCore.Mvc;

namespace NovelWebsite.NovelWebsite.Application.Admin.Controllers
{
    [Area("Admin")]
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
