using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class UserRoleModel : BaseEntity
    {
        public string UserRoleId { get; set; }
        public string UserRoleName { get; set; }
    }
}
