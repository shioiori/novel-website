using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using NovelWebsite.Models;

namespace NovelWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly AppDbContext _dbContext;

        public RoleController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOrUpdateRole(RoleModel roleModel)
        {
            var role = _dbContext.Roles.FirstOrDefault(r => r.RoleId == roleModel.RoleId);
            if (roleModel.RoleId == 0)
            {
                role = new RoleEntity()
                {
                    RoleName = roleModel.RoleName,
                };
                _dbContext.Roles.Add(role);
            }
            else
            {
                role.RoleName = roleModel.RoleName;
                _dbContext.Roles.Update(role);
            }
            _dbContext.SaveChanges();
            return Redirect("/Admin/Role/Index");
        }

        public IActionResult DeleteRole(int roleId)
        {
            var role = _dbContext.Roles.First(r => r.RoleId == roleId);
            role.IsDeleted = true;
            _dbContext.Roles.Update(role);
            _dbContext.SaveChanges();
            return Redirect("/Admin/Role/Index");

        }
    }
}
