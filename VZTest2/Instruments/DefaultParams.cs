using X.PagedList.Web.Common;

namespace VZTest2.Instruments
{
    public static class DefaultParams
    {
        public static readonly PagedListRenderOptions DefaultPagedListRenderOptions = new PagedListRenderOptions
        {
            LinkToNextPageFormat = "<i class=\"bi bi-chevron-right\"></i>",
            LinkToPreviousPageFormat = "<i class=\"bi bi-chevron-left\"></i>",
            LinkToLastPageFormat = "<i class=\"bi bi-chevron-double-right\"></i>",
            LinkToFirstPageFormat = "<i class=\"bi bi-chevron-double-left\"></i>",
            UlElementClasses = new string[] { "pagination m-0" },
            LiElementClasses = new string[] { "page-item" },
            PageClasses = new string[] { "page-link" }
        };
    }
}
