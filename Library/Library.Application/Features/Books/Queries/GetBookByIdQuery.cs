using Library.Application.Interfaces.Repositories;
using Library.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Books.Queries
{
    public record GetBookByIdQuery(int Id) : IRequest<BookDto>;

    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBookByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BookDto?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(request.Id);
            return book != null
                ? new BookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    PublicationYear = book.PublicationYear,
                    ISBN = book.ISBN,
                    Genre = book.Genre,
                    Publisher = book.Publisher,
                    PageCount = book.PageCount,
                    Language = book.Language,
                    Summary = book.Summary,
                    AvailableCopies = book.AvailableCopies
                }
                : null;
        }
    }

}
