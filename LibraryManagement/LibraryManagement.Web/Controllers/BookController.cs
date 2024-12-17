using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Application.Common.Utility;
using LibraryManagement.Application.Services.Interface;
using LibraryManagement.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Web.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            return View(_bookService.GetAll());
        }

        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = SD.Role_Admin)]
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.Create(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [Authorize(Roles = SD.Role_Admin)]
        [HttpGet("Book/Update/{id}")]
        public IActionResult Update(Guid id)
        {
            Book? book = _bookService.GetById(id);

            if (book == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(book);
        }

        [Authorize(Roles = SD.Role_Admin)]
        [HttpPost]
        public IActionResult Update(Book book)
        {
            if (ModelState.IsValid) 
            {
                _bookService.Update(book);
                TempData["success"] = "Book updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [Authorize(Roles = SD.Role_Admin)]
        [HttpGet("Book/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            Book? book = _bookService.GetById(id);

            if (book == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(book);
        }

        [Authorize(Roles = SD.Role_Admin)]
        [HttpPost]
        public IActionResult Delete(Book book)
        {
            var deleted =_bookService.Delete(book.Id);

            if (deleted)
            {
                //TODO: add notification
                return RedirectToAction(nameof(Index));
            }

            //TODO: add error notification

            return View(book);
        }
    }
}
