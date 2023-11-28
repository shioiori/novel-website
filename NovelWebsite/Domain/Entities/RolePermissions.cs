using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Domain.Entities
{
    public class RolePermissions
    {
        [ForeignKey("fk_rp_role")]
        public string RoleId { get; set; }
        [ForeignKey("fk_rp_per")]
        public int PermissionId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
