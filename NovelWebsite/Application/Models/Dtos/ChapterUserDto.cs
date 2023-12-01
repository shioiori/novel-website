using NovelWebsite.Application.Models.Objects;

namespace NovelWebsite.Application.Models.Dtos
{
    public class ChapterUserDto
    {
        public ChapterDto Chapter { get; set; }
        public UserDto User { get; set; }
        public Interaction Interaction {  get; set; } 
    }
}
