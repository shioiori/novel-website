using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Application.Controllers
{
    public class ConfirmMailController : Controller
    {

        private readonly IMailService _mailService;
        public ConfirmMailController(IMailService mailService) 
        {
            _mailService = mailService;
        }

        [Route("/email-confimation")]
        public IActionResult Index(string email, string token)
        {
            var response = _mailService.ConfirmEmail(email, token);
            return View(response);
        }
    }
}
