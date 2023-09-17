using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using System.Security.Claims;

namespace NovelWebsite.NovelWebsite.Application.Components
{
    public class UserNavbarViewComponent : ViewComponent
    {
        private readonly IUserService _userService;

        public UserNavbarViewComponent(IUserService userService)
        {
            _userService = userService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_userService.GetCurrentUser());
        }

    }
}
