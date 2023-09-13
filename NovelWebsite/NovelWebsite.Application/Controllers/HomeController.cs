using Microsoft.AspNetCore.Mvc;

namespace NovelWebsite.Application.Controllers
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
