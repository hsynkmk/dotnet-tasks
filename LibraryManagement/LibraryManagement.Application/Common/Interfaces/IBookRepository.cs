using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.Common.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        void Update(Book entity);

        void Save();
    }
}
