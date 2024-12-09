namespace BestApi.Models
{
    public record PaginatedResponse<T>(int PageNumber, int PageSize, int TotalPages, int TotalRecords, IEnumerable<T> Data);
}
