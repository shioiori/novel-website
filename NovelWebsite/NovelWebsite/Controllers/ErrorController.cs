using Microsoft.AspNetCore.Mvc;

namespace NovelWebsite.Controllers
{
    [Route("/Error")]
    public class ErrorController : Controller
    {
        [Route("{errCode}")]
        public IActionResult Error(string errCode)
        {
            return View($"~/Views/Error/{errCode}.cshtml");
        }

        [Route("Log")]
        public IActionResult Log()
        {
            ViewBag.Log = TempData["log"];
            return View();
        }

    }
}
