using Library.Application.Features.Books.Commands;
using Library.Application.Features.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return View(books);
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery(id));
            if (book == null) return NotFound();
            return View(book);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(AddBookCommand command)
        {
            if (!ModelState.IsValid) return View(command);

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery(id));
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateBookCommand command)
        {
            if (!ModelState.IsValid) return View(command);

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery(id));
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new DeleteBookCommand(id));
            return RedirectToAction(nameof(Index));
        }
    }

}
