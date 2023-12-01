using NovelWebsite.Application.Models.Objects;

namespace NovelWebsite.Application.Models.Dtos
{
    public class ReviewUserDto
    {
        public ReviewDto Review { get; set; }
        public UserDto User { get; set; }
        public Interaction Interaction {  get; set; } 
    }
}
