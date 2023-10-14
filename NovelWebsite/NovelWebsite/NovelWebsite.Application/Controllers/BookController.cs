using Microsoft.AspNetCore.Mvc;

namespace NovelWebsite.NovelWebsite.Application.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
