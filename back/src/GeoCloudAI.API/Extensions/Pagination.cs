using System.Text.Json;
using GeoCloudAI.API.Models;

namespace GeoCloudAI.API.Extensions
{
    public static class Pagination
    {
        public static void AddPagination(this HttpResponse response,
            int totalCount, int currentPage, int pageSize, int totalPages)
        {
            var pagination = new PaginationHeaders(totalCount, currentPage, pageSize, totalPages);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            response.Headers.Add("Pagination", JsonSerializer.Serialize(pagination, options));
            
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}