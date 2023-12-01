using NovelWebsite.Application.Models.Objects;

namespace NovelWebsite.Application.Models.Dtos
{
    public class CommentUserDto
    {
        public CommentDto Comment { get; set; }
        public UserDto User { get; set; }
        public Interaction Interaction {  get; set; } 
    }
}
