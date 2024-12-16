using Library.Application.Interfaces.Repositories;
using Library.Application.Models;
using MediatR;

namespace Library.Application.Features.Books.Queries
{
    public record GetBooksQuery : IRequest<IEnumerable<BookDto>>;

    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBooksQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Books.GetAllAsync();
        }
    }

}
