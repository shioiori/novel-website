using NovelWebsite.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Models
{
    public class UserEntity : BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string? Avatar { get; set; }
        public string? CoverPhoto { get; set; }
        public string? Email { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public RoleEntity Role { get; set; }
    }
}
