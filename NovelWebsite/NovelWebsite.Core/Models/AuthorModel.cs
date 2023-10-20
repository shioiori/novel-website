using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.NovelWebsite.Core.Models
{
    public class AuthorModel
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Slug { get; set; }
    }
}
