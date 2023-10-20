using NovelWebsite.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class User_Role
    {
        [ForeignKey("fk_ur_user")]
        public int UserId { get; set; }
        [ForeignKey("fk_ur_role")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
