using System.ComponentModel.DataAnnotations;
using NovelWebsite.Infrastructure.Entities;

namespace NovelWebsite.NovelWebsite.Core.Models
{
    public class UserRoleModel : BaseEntity
    {
        public string UserRoleId { get; set; }
        public string UserRoleName { get; set; }
    }
}
