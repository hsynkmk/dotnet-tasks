using Library.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Books.Commands
{
    public record UpdateBookCommand(int Id, string Title, string Author, int PublicationYear, string ISBN, string Genre, string Publisher, int PageCount, string Language, string Summary, int AvailableCopies) : IRequest<bool>;

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(request.Id);
            if (book == null)
            {
                return false; // Book not found
            }

            book.Title = request.Title;
            book.Author = request.Author;
            book.PublicationYear = request.PublicationYear;
            book.ISBN = request.ISBN;
            book.Genre = request.Genre;
            book.Publisher = request.Publisher;
            book.PageCount = request.PageCount;
            book.Language = request.Language;
            book.Summary = request.Summary;
            book.AvailableCopies = request.AvailableCopies;

            await _unitOfWork.Books.UpdateAsync(book);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }

}
