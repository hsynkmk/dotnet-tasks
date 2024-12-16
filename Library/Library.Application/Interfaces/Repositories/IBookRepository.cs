using Library.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces.Repositories
{
    public interface IBookRepository : IRepositoryBase<BookDto>
    {
        Task<IEnumerable<BookDto>> SearchBooksAsync(string searchTerm);
    }
}
