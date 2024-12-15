using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Infrastructure.Data;
using LibraryManagement.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagement.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.Books.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Books.Add(book);
                _unitOfWork.Books.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [HttpGet("Book/Update/{id}")]
        public IActionResult Update(Guid id)
        {
            Book? book = _unitOfWork.Books.Get(u => u.Id == id);

            if (book == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Update(Book book)
        {
            if (ModelState.IsValid) 
            {
                _unitOfWork.Books.Update(book);
                _unitOfWork.Books.Save();
                TempData["success"] = "Book updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [HttpGet("Book/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            Book? book = _unitOfWork.Books.Get(u => u.Id == id);

            if (book == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            Book? bookFromDb = _unitOfWork.Books.Get(u => u.Id == book.Id);

            if (bookFromDb != null)
            {
                _unitOfWork.Books.Remove(bookFromDb);
                _unitOfWork.Books.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
    }
}
