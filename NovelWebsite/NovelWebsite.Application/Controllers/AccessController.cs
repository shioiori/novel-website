

using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.Application.Controllers
{
    public class AccessController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAuthorizationService _authorizationService;

        public AccessController(IAuthenticationService authenticationService, IAuthorizationService authorizationService)
        {
            _authenticationService = authenticationService;
            _authorizationService = authorizationService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            var response = _authenticationService.Login(request);
            return View(response);
        }

        [HttpPost]
        public IActionResult Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).First();
                return View(new AuthenticationResponse()
                {
                    Success = false,
                    Message = error,
                });
            }
            var response = _authenticationService.Register(request);
            return View(response);
        }


        public IActionResult Signout(string returnUrl)
        {
            _authorizationService.RemoveClaims();
            return Redirect(returnUrl);
        }
    }
}
