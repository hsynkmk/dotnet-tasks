using BestApi.DTOs;
using BestApi.Models;

namespace BestApi.Services
{
    public interface IBookService
    {
        Task<PaginatedResponse<BookDto>> GetBooksAsync(int pageNumber, int pageSize);
        Task<BookDto?> GetBookByIdAsync(int id);
        Task CreateBookAsync(CreateBookDto createBookDto);
        Task UpdateBookAsync(int id, UpdateBookDto updateBookDto);
        Task DeleteBookAsync(int id);
    }
}