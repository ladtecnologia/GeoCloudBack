namespace GeoCloudAI.Persistence.Models
{
    public class PageList<T> : List<T>
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public PageList() {  }
        
        public PageList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount  = count;
            CurrentPage = pageNumber;
            PageSize    = pageSize;
            TotalPages  = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static async Task<PageList<T>> CreateAsync(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber-1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();
            return new PageList<T>(items, count, pageNumber, pageSize);
        }
    }
}