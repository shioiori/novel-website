using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class RoleEntity : BaseEntity
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
