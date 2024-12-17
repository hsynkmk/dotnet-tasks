using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Application.Services.Interface;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.Services.Implementation
{
    public class BookService(IUnitOfWork unitOfWork) : IBookService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public void Create(Book book)
        {
            _unitOfWork.Books.Add(book);
            _unitOfWork.Books.Save();
        }

        public bool Delete(Guid id)
        {
            try
            {
                Book? bookFromDb = _unitOfWork.Books.Get(u => u.Id == id);

                if (bookFromDb != null)
                {
                    _unitOfWork.Books.Remove(bookFromDb);
                    _unitOfWork.Books.Save();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Book> GetAll()
        {
            return _unitOfWork.Books.GetAll();
        }

        public Book GetById(Guid id)
        {
            return _unitOfWork.Books.Get(u => u.Id == id);
        }

        public void Update(Book book)
        {
            _unitOfWork.Books.Update(book);
            _unitOfWork.Books.Save();
        }
    }
}
