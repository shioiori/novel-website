using Microsoft.AspNetCore.Mvc;

namespace NovelWebsite.NovelWebsite.Application.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
