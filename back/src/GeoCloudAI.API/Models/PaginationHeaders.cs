namespace GeoCloudAI.API.Models
{
    public class PaginationHeaders
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public PaginationHeaders(int totalCount, int currentPage, int pageSize, int totalPages) 
        {
            this.TotalCount  = totalCount;
            this.CurrentPage = currentPage;
            this.PageSize    = pageSize;
            this.TotalPages  = totalPages;
        }
    }
}