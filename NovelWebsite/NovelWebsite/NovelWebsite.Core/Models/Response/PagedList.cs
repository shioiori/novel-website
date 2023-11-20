using NovelWebsite.NovelWebsite.Core.Models.Request;

namespace NovelWebsite.NovelWebsite.Core.Models.Response
{
    public class PagedList<T>
    {
        public int Total { get; set; } = 0;
        public int PerPage { get; set; } = 10;
        public int CurrentPage { get; set; } = 1;
        public int LastPage { get; set; } = 1;
        public int FirstPageUrl { get; set; }
        public int LastPageUrl {  get; set; }
        public int PrevPageUrl {  get; set; }
        public int NextPageUrl { get; set; }
        public int From { get; set; } = 1;
        public int To { get; set; } = 1;
        public List<T> Data {  get; set; }

        public PagedList(T data, int PageSize = 10, int currentPage = 1)
        {
            Data = new List<T> { data };
            SplitPage(PageSize);
            SetCurrentPage(currentPage);
        }

        public PagedList(IEnumerable<T> data, int PageSize = 10, int currentPage = 1)
        {
            Data = data.ToList();
            SplitPage(PageSize);
            SetCurrentPage(currentPage);
        }

        private void SplitPage(int PageSize = 10)
        {
            PerPage = (int)PageSize;
            Total = Data.Count();
            LastPage = (int)Math.Ceiling(Total * 1.0 / PerPage);
        }

        private void SetCurrentPage(int currentPage = 1)
        {
            CurrentPage = (int)currentPage;
            From = PerPage * CurrentPage - PerPage + 1;
            To = From + PerPage;
            Data = Data.Skip(PerPage * CurrentPage - PerPage).Take(PerPage).ToList();
        }
        public static PagedList<T> ToPagedList(IEnumerable<T> source, int PageSize = 10, int pageNumber = 1)
        {
            return new PagedList<T>(source, PageSize, pageNumber);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> source, PagedListRequest request)
        {
            return new PagedList<T>(source, request.PageSize, request.CurrentPage);
        }
    }
}
