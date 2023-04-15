using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using System.Security.Claims;

namespace NovelWebsite.Components
{
    public class UserNavbarViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public UserNavbarViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IViewComponentResult Invoke()
        {
            var account = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.Identity.AuthenticationType == GoogleDefaults.AuthenticationScheme)
            {
                account += "@google";
            }
            if (User.Identity.AuthenticationType == FacebookDefaults.AuthenticationScheme)
            {
                account += "@facebook";
            }
            var user = _dbContext.Accounts.Where(a => a.AccountName == account).FirstOrDefault();
            return View(user);
        }

    }
}
