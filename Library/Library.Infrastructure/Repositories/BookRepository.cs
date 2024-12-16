using Library.Application.Interfaces.Repositories;
using Library.Application.Models;
using Library.Domain.Entities;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context) { }

        public Task AddAsync(BookDto entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(BookDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookDto>> SearchBooksAsync(string searchTerm)
        {
            return await _context.Books
                .Where(b => b.Title.Contains(searchTerm) || b.Author.Contains(searchTerm))
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ISBN = b.ISBN,
                    PublicationYear = b.PublicationYear
                })
                .ToListAsync();
        }

        public Task UpdateAsync(BookDto entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<BookDto>> IRepositoryBase<BookDto>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<BookDto?> IRepositoryBase<BookDto>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }

}
