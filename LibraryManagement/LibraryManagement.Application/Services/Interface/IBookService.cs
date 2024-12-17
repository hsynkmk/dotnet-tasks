using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.Services.Interface
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        Book GetById(Guid id);
        void Create(Book book);
        void Update(Book book);
        bool Delete(Guid id);
    }
}
//TODO: Return with response DTO
