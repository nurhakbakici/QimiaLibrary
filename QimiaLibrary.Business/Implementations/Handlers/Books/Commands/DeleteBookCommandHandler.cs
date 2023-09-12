using MediatR;
using QimiaLibrary.Business.Abstractions;
using QimiaLibrary.Business.Implementations.Commands.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Handlers.Books.Commands;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
{
    private readonly IBookManager _bookManager;
    public DeleteBookCommandHandler(IBookManager bookManager)
    {
        _bookManager = bookManager;
    }

    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookManager.GetBookByIdAsync(request.BookId, cancellationToken);

        book.BStatusID = 4;

        await _bookManager.UpdateBookAsync(book, cancellationToken);

        return Unit.Value;
    }
}
