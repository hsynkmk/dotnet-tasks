﻿using BestApi.Models;

namespace BestApi.Services
{
    public interface IBookService
    {
        Task<PaginatedResponse<Book>> GetBooksAsync(int pageNumber, int pageSize);
        Task<Book> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
    }
}