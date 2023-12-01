using NovelWebsite.Application.Models.Objects;

namespace NovelWebsite.Application.Models.Dtos
{
    public class BookUserDto
    {
        public BookDto Book { get; set; }
        public UserDto User { get; set; }
        public Interaction Interaction {  get; set; } 
    }
}
