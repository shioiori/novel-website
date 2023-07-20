using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;
using System.Security.Claims;

namespace NovelWebsite.Components
{
    public class UserNotificationViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public UserNotificationViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IViewComponentResult Invoke()
        {
            try
            {
                int userId = int.Parse(HttpContext.User.FindFirstValue("UserId"));
                return View(_dbContext.Notifications.Where(x => x.ToUserId == userId)
                                                    .Include(x => x.Type)
                                                    .Include(x => x.FromUser)
                                                    .OrderByDescending(x => x.CreatedDate).ToList());
            }
            catch (Exception ex)
            {
                return View(new List<NotificationEntity>());
            }
        }
    }
}
