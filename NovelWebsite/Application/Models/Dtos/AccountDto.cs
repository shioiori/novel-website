using NovelWebsite.Domain.Enums;

namespace Application.Models.Dtos
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public AccountRole Role { get; set; }
        public UserDto User { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LoginProvide { get; set; }
        public int Status { get; set; }
    }
}
