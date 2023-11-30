using Application.Models.Objects;
using NovelWebsite.Domain.Enums;

namespace Application.Models.Dtos
{
    public class UserDto
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; } = "default.jpg";
        public string CoverPhoto { get; set; } = "default.jpg";
        public DateTime? CreatedDate { get; set; }
        public int Status { get; set; } = (int)AccountStatus.Verifying;
        public Label StatusLabel { get; set; }
        public IEnumerable<RoleDto> Role { get; set; }
    }
}
