using LibraryManagement.Domain.Entities;
using LibraryManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Web.Controllers
{
    public class BookController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;

        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
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
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet("Book/Update/{id}")]
        public IActionResult Update(Guid id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Update(Book book)
        {
            if (ModelState.IsValid && _context.Books.Any(b => b.Id == book.Id)) 
            {
                _context.Books.Update(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet("Book/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            var bookFromDb = _context.Books.FirstOrDefault(b => b.Id == book.Id);

            if (bookFromDb != null)
            {
                _context.Books.Remove(bookFromDb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }
    }
}
