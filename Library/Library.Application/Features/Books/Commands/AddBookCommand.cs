using Library.Application.Interfaces.Repositories;
using Library.Application.Models;
using MediatR;

namespace Library.Application.Features.Books.Commands
{
    public record AddBookCommand(string Title, string Author, int PublicationYear, string ISBN) : IRequest<int>;

    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = new BookDto
            {
                Title = request.Title,
                Author = request.Author,
                PublicationYear = request.PublicationYear,
                ISBN = request.ISBN,
            };

            await _unitOfWork.Books.AddAsync(book);
            await _unitOfWork.SaveChangesAsync();

            return book.Id;
        }
    }
}
