using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelWebsite.Application.Models.Filters
{
    public class CommentFilter
    {
        [FromQuery(Name = "book")]
        public string? BookId { get; set; }
        [FromQuery(Name = "post")]
        public string? PostId { get; set; }
        [FromQuery(Name = "chapter")]
        public string? ChapterId { get; set; }
        [FromQuery(Name = "review")]
        public string? ReviewId { get; set; }
    }
}
