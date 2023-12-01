using Microsoft.AspNetCore.Mvc;

namespace NovelWebsite.Application.Models.Requests
{
    public class PagedListRequest
    {
        [FromQuery(Name = "size")]
        public int PageSize { get; set; } = 0;
        [FromQuery(Name = "current_page")]
        public int CurrentPage { get; set; } = 0;
    }
}
