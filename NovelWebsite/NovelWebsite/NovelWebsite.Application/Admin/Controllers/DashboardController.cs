using Microsoft.AspNetCore.Mvc;

namespace NovelWebsite.NovelWebsite.Application.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
