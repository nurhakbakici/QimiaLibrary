using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Commands.Books;

public class DeleteBookCommand : IRequest<Unit>
{
    public int BookId { get;}

    public DeleteBookCommand(int bookId)
    {
        BookId = bookId;
    }
}
