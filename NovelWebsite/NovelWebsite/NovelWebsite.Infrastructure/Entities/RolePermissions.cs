using Microsoft.AspNetCore.Identity;
using NovelWebsite.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.NovelWebsite.Infrastructure.Entities
{
    public class RolePermissions
    {
        [ForeignKey("fk_rp_role")]
        public int RoleId { get; set; }
        [ForeignKey("fk_rp_per")]
        public int PermissionId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
