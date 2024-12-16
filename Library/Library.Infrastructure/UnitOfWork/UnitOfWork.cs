using Library.Application.Interfaces.Repositories;
using Library.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context, IBookRepository books)
        {
            _context = context;
            Books = books;
        }

        public IBookRepository Books { get; }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }

}
