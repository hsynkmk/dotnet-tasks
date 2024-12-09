using BestApi.Models;

namespace BestApi.Repositories
{
    public interface IBookRepository
    {
        Task<PaginatedResponse<Book>> GetBooksAsync(int pageNumber, int pageSize);
        Task<Book> GetBookByIdAsync(int id);
        Task CreateBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
    }
}
