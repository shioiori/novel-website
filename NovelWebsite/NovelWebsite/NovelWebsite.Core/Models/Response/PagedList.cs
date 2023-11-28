using NovelWebsite.NovelWebsite.Core.Models.Request;
using System.Drawing.Printing;

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
        public IEnumerable<T> Data { get; set; } = null;
        private IQueryable<T> Query;

        public PagedList(T data, int pageSize = 10, int currentPage = 1)
        {
            Data = new List<T> { data };
            SplitPage(pageSize);
            SetCurrentPage(currentPage);
        }

        public PagedList(IQueryable<T> data, int pageSize = 10, int currentPage = 1)
        {
            Query = data;
            SplitPage(pageSize);
            SetCurrentPage(currentPage);
        }

        public PagedList(IEnumerable<T> data, int pageSize = 10, int currentPage = 1)
        {
            Data = data;
            SplitPage(pageSize);
            SetCurrentPage(currentPage);
        }

        private void SplitPage(int pageSize = 10)
        {
            PerPage = (int)pageSize;
            if (this.Query != null)
            {
                Total = Query.Count();
            }
            else
            {
                Total = Data.Count();
            }
            LastPage = (int)Math.Ceiling(Total * 1.0 / PerPage);
        }

        private void SetCurrentPage(int currentPage = 1)
        {
            CurrentPage = (int)currentPage;
            From = PerPage * CurrentPage - PerPage + 1;
            To = (From + PerPage) <= Total ? From + PerPage : Total;
            if (this.Query != null)
            {
                Query = Query.Skip(PerPage * CurrentPage - PerPage).Take(PerPage);
                Data = Query.AsEnumerable();
                return;
            }
            Data = Data.Skip(PerPage * CurrentPage - PerPage).Take(PerPage).AsEnumerable();
        }
        public static PagedList<T> ToPagedList(IEnumerable<T> source)
        {
            PagedListRequest request = new PagedListRequest()
            {
                PageSize = source.Count(),
                CurrentPage = 1,
            };
            return new PagedList<T>(source, request.PageSize, request.CurrentPage);
        }
        
        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageSize, int pageNumber)
        {
            return new PagedList<T>(source, pageSize, pageNumber);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> source, PagedListRequest request)
        {

            if (request == null || request.CurrentPage == 0)
            {
                request = new PagedListRequest() { 
                    PageSize = source.Count(),
                    CurrentPage = 1,
                };
            }
            return new PagedList<T>(source, request.PageSize, request.CurrentPage);
        }

        public static IEnumerable<T> AsEnumerable(IQueryable<T> source, int pageSize, int pageNumber)
        {
            return new PagedList<T>(source, pageSize, pageNumber).Data;
        }

        public static IEnumerable<T> AsEnumerable(IQueryable<T> source, PagedListRequest request)
        {
            if (request == null || request.CurrentPage == 0)
            {
                request = new PagedListRequest()
                {
                    PageSize = source.Count(),
                    CurrentPage = 1,
                };
            }
            return new PagedList<T>(source, request.PageSize, request.CurrentPage).Data;
        }

        public static IEnumerable<T> AsEnumerable(IEnumerable<T> source)
        {
            PagedListRequest request = new PagedListRequest()
            {
                PageSize = source.Count(),
                CurrentPage = 1,
            };
            return new PagedList<T>(source, request.PageSize, request.CurrentPage).Data;
        }
        public static IEnumerable<T> AsEnumerable(IEnumerable<T> source, PagedListRequest request)
        {
            if (request == null || request.CurrentPage == 0)
            {
                request = new PagedListRequest()
                {
                    PageSize = source.Count(),
                    CurrentPage = 1,
                };
            }
            return new PagedList<T>(source, request.PageSize, request.CurrentPage).Data;
        }
    }
}
