using Microsoft.AspNetCore.Mvc;

namespace NovelWebsite.Application.Models.Request
{
    public class PagedListRequest
    {
        [FromQuery(Name = "size")]
        public int PageSize { get; set; } = 0;
        [FromQuery(Name = "current")]
        public int CurrentPage { get; set; } = 0;
    }
}
