using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;
using NovelWebsite.Models;

namespace NovelWebsite.Controllers
{

    [ApiController]
    [Route("/notification")]
    public class NotificationController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public NotificationController(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public bool AddNotification(NotificationModel notification)
        {
            try
            {
                _dbContext.Notifications.Add(new NotificationEntity()
                {
                    FromUserId = notification.FromUserId,
                    ToUserId = notification.ToUserId,
                    TypeId = notification.TypeId,
                    CreatedDate = DateTime.Now,
                });
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }   
        }
    }
}
