using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagement.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IActionResult Index()
        {
            return View(_bookRepository.GetAll());
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
                _bookRepository.Add(book);
                _bookRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [HttpGet("Book/Update/{id}")]
        public IActionResult Update(Guid id)
        {
            Book? book = _bookRepository.Get(u => u.Id == id);

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
                _bookRepository.Update(book);
                _bookRepository.Save();
                TempData["success"] = "Book updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [HttpGet("Book/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            Book? book = _bookRepository.Get(u => u.Id == id);

            if (book == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            Book? bookFromDb = _bookRepository.Get(u => u.Id == book.Id);

            if (bookFromDb != null)
            {
                _bookRepository.Remove(bookFromDb);
                _bookRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
    }
}
