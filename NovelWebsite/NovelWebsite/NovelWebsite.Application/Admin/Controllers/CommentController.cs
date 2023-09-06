using Microsoft.AspNetCore.Mvc;

namespace NovelWebsite.NovelWebsite.Application.Admin.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
