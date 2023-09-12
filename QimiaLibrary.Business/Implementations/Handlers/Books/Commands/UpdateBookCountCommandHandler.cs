using MediatR;
using QimiaLibrary.Business.Abstractions;
using QimiaLibrary.Business.Implementations.Commands.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Handlers.Books.Commands;

public class UpdateBookCountCommandHandler : IRequestHandler<UpdateBookCountCommand, Unit>
{
    private readonly IBookManager _bookManager;
    public UpdateBookCountCommandHandler(IBookManager bookManager)
    {
        _bookManager = bookManager;
    }

    public async Task<Unit> Handle(UpdateBookCountCommand request, CancellationToken cancellationToken)
    {
        if(request.Book.Count <= 0)
        {
            throw new InvalidOperationException("count of a book can't be lower than zero");
        }
        else
        {
            var book = await _bookManager.GetBookByIdAsync(request.BookId, cancellationToken);

            book.Count = request.Book.Count;

            await _bookManager.UpdateBookAsync(book, cancellationToken);

            return Unit.Value;
        }
    }
}
