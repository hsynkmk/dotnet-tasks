using BestApi.DTOs;
using BestApi.Models;
using BestApi.Repositories;
using StackExchange.Redis;
using System.Text.Json;

namespace BestApi.Services
{
    public class BookService(IBookRepository repository, IConnectionMultiplexer redis) : IBookService
    {
        private readonly IBookRepository _repository = repository;
        private readonly IDatabase _redisCache = redis.GetDatabase();

        public async Task<PaginatedResponse<BookDto>> GetBooksAsync(int pageNumber, int pageSize) 
        {
            string cacheKey = $"Books_Page_{pageNumber}_Size_{pageSize}";
            var cachedData = await _redisCache.StringGetAsync(cacheKey);

            if (!cachedData.IsNullOrEmpty)
            {
                return JsonSerializer.Deserialize<PaginatedResponse<BookDto>>(cachedData);
            }

            var books = await _repository.GetBooksAsync(pageNumber, pageSize);
            var bookDtos = books.Data.Select(b => new BookDto(b.Id, b.Title, b.Author, b.PublishedDate)).ToList();

            var response = new PaginatedResponse<BookDto>(
                books.PageNumber,
                books.PageSize,
                books.TotalPages,
                books.TotalRecords,
                bookDtos
            );

            await _redisCache.StringSetAsync(cacheKey, JsonSerializer.Serialize(response), TimeSpan.FromMinutes(10));
            return response;
        }

        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            var book = await _repository.GetBookByIdAsync(id);

            // We can use AutoMapper instead of manual mapping
            return book == null ? null : new BookDto(book.Id, book.Title, book.Author, book.PublishedDate);
        }

        public async Task CreateBookAsync(CreateBookDto createBookDto)
        {
            var book = new Book
            {
                Title = createBookDto.Title,
                Author = createBookDto.Author,
                PublishedDate = createBookDto.PublishedDate,
            };
            await _repository.CreateBookAsync(book);
        }

        public async Task UpdateBookAsync(int id, UpdateBookDto updateBookDto)
        {
            var book = await _repository.GetBookByIdAsync(id) ?? throw new KeyNotFoundException("Book not found");
            book.Title = updateBookDto.Title;
            book.Author = updateBookDto.Author;
            book.PublishedDate = updateBookDto.PublishedDate;

            await _repository.UpdateBookAsync(book);
        }

        public Task DeleteBookAsync(int id) =>
            _repository.DeleteBookAsync(id);
    }
}
