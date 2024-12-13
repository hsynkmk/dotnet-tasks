using BestApi.Data;
using BestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BestApi.Repositories
{
    public class BookRepository(ApplicationDbContext context) : IBookRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<PaginatedResponse<Book>> GetBooksAsync(int pageNumber, int pageSize)
        {
            var totalRecords = await _context.Books.CountAsync();
            var books = await _context.Books
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResponse<Book>(
                PageNumber: pageNumber,
                PageSize: pageSize,
                TotalPages: (int)Math.Ceiling((double)totalRecords / pageSize),
                TotalRecords: totalRecords,
                Data: books
            );
        }

        public async Task<Book> GetBookByIdAsync(int id) => await _context.Books.FindAsync(id);

        public async Task CreateBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await GetBookByIdAsync(id) ?? throw new Exception("Book not found");
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
