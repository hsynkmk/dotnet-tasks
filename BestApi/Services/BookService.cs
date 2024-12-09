using BestApi.Models;
using BestApi.Repositories;

namespace BestApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public Task<PaginatedResponse<Book>> GetBooksAsync(int pageNumber, int pageSize) =>
            _repository.GetBooksAsync(pageNumber, pageSize);

        public Task<Book> GetBookByIdAsync(int id) =>
            _repository.GetBookByIdAsync(id);

        public Task AddBookAsync(Book book) =>
            _repository.AddBookAsync(book);

        public Task UpdateBookAsync(Book book) =>
            _repository.UpdateBookAsync(book);

        public Task DeleteBookAsync(int id) =>
            _repository.DeleteBookAsync(id);
    }
}
