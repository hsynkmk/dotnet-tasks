using Library.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Features.Books.Commands
{
    public record DeleteBookCommand(int Id) : IRequest<bool>;

    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(request.Id);
            if (book == null)
            {
                return false; // Book not found
            }

            await _unitOfWork.Books.DeleteAsync(book);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }

}
