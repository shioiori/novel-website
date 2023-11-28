﻿namespace NovelWebsite.NovelWebsite.Core.Models.Request
{
    public class PagedListRequest
    {
        public int PageSize { get; set; } = 0;
        public int CurrentPage { get; set; } = 0;
    }
}
