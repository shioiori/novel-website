using NovelWebsite.Application.Models.Objects;

namespace NovelWebsite.Application.Models.Dtos
{
    public class PostUserDto
    {
        public PostDto Post { get; set; }
        public UserDto User { get; set; }
        public Interaction Interaction {  get; set; } 
    }
}
