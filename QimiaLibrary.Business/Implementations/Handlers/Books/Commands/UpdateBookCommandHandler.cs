using MediatR;
using QimiaLibrary.Business.Abstractions;
using QimiaLibrary.Business.Implementations.Commands.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Handlers.Books.Commands;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
{
    private readonly IBookManager _bookManager;

    public UpdateBookCommandHandler(IBookManager bookManager)
    {
        _bookManager = bookManager;
    }

    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookManager.GetBookByIdAsync(request.BookId, cancellationToken);

        book.Title = request.Book.Title;
        book.Author = request.Book.Author;

        await _bookManager.UpdateBookAsync(book, cancellationToken);

        return Unit.Value;
    }
}
