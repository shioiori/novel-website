using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;
using NovelWebsite.Models;
using System.Security.Claims;

namespace NovelWebsite.Controllers
{
    public class FacebookController : Controller
    {
        private readonly AppDbContext _dbContext;

        public FacebookController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("/login-facebook")]
        public IActionResult LoginWithFacebook()
        {
            var authenticationProperties = new AuthenticationProperties
            {
                RedirectUri = "/facebook-login-callback",
                Items =
                {
                    { "scheme", FacebookDefaults.AuthenticationScheme }
                }
            };
            return Challenge(authenticationProperties, FacebookDefaults.AuthenticationScheme);
        }

        [Route("/facebook-login-callback")]
        public async Task<IActionResult> HandleFacebookResponseLogIn()
        {
            var result = await HttpContext.AuthenticateAsync(FacebookDefaults.AuthenticationScheme);
            if (result?.Principal is { Identity: { IsAuthenticated: true } } principal)
            {
                var email = principal.FindFirst(ClaimTypes.Email)?.Value;
                if (_dbContext.Users.FirstOrDefault(x => x.Email == email) != null)
                {
                    var identity = result.Principal.Identity as ClaimsIdentity;
                    var accountName = principal.FindFirstValue(ClaimTypes.NameIdentifier) + "@facebook";
                    var account = _dbContext.Accounts.Where(a => a.AccountName == accountName)
                                                     .Include(a => a.User).ThenInclude(a => a.Role)
                                                     .FirstOrDefault();
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, accountName));
                    identity.AddClaim(new Claim(ClaimTypes.Role, account.User.Role.RoleName));
                    identity.AddClaim(new Claim("UserId", account.UserId.ToString()));
                    identity.AddClaim(new Claim("Username", account.User.UserName));
                    identity.AddClaim(new Claim("Avatar", account.User.Avatar));
                    await HttpContext.SignInAsync(result.Principal, result.Properties);
                    return Redirect("/");
                }
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                TempData["log"] = "Tài khoản này chưa đăng ký!";
                return Redirect("/Error/Log");
            }
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["log"] = "Đăng nhập thất bại";
            return Redirect("/Error/Log");
        }

        [Route("/signup-facebook")]
        public IActionResult SignUpWithFacebook()
        {
            var authenticationProperties = new AuthenticationProperties
            {
                RedirectUri = "/facebook-signup-callback",
                Items =
                {
                    { "scheme", FacebookDefaults.AuthenticationScheme }
                }
            };
            return Challenge(authenticationProperties, FacebookDefaults.AuthenticationScheme);
        }

        [Route("/facebook-signup-callback")]
        public async Task<IActionResult> HandleFacebookResponseSignUp()
        {
            var result = await HttpContext.AuthenticateAsync(FacebookDefaults.AuthenticationScheme);
            if (result?.Principal is { Identity: { IsAuthenticated: true } } principal)
            {
                var accountName = principal.FindFirstValue(ClaimTypes.NameIdentifier) + "@facebook";
                await HttpContext.SignInAsync(result.Principal, result.Properties);
                var email = principal.FindFirst(ClaimTypes.Email)?.Value;
                if (_dbContext.Users.FirstOrDefault(x => x.Email == email) != null)
                {
                    TempData["log"] = "Tài khoản này đã được đăng ký";
                    return Redirect("/Error/Log");
                }
                var user = new UserEntity()
                {
                    UserName = principal.FindFirst(ClaimTypes.Name)?.Value,
                    Email = email,
                    Avatar = "/image/default.jpg",
                    CoverPhoto = "/image/bg_default.png",
                    RoleId = 3,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Status = 0,
                    IsDeleted = false,
                };
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                var acc = new AccountEntity()
                {
                    UserId = user.UserId,
                    AccountName = accountName,
                    Password = email.Split("@")[0],
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Status = 0,
                    IsDeleted = false,
                };
                _dbContext.Accounts.Add(acc);
                _dbContext.SaveChanges();
                var identity = result.Principal.Identity as ClaimsIdentity;
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, accountName));
                identity.AddClaim(new Claim(ClaimTypes.Role, "Người dùng"));
                identity.AddClaim(new Claim("UserId", acc.UserId.ToString()));
                identity.AddClaim(new Claim("Username", user.UserName));
                identity.AddClaim(new Claim("Avatar", user.Avatar));
                await HttpContext.SignInAsync(result.Principal, result.Properties);
                return Redirect("/");
            }
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["log"] = "Đăng ký thất bại";
            return Redirect("/Error/Log");
        }
    }
}
