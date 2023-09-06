using MediatR;
using Microsoft.Identity.Client;
using QimiaLibrary.Business.Implementations.Commands.Books.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Commands.Books;

public class UpdateBookCountCommand : IRequest<Unit>
{
    public int BookId { get; }
    public UpdateBookCountDto Book { get; set; }

    public UpdateBookCountCommand(int bookId, UpdateBookCountDto book)
    {
        BookId = bookId;
        Book = book;
    }
}
