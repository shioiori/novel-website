using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Infrastructure.Entities
{
    public class Role : BaseEntity
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
