using MediatR;
using QimiaLibrary.Business.Implementations.Commands.Books.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Commands.Books;

public class UpdateBookCommand : IRequest<Unit>
{
    public int BookId { get; }
    public UpdateBookDto Book { get; set; }

    public UpdateBookCommand(int bookId, UpdateBookDto book)    
    {
        BookId = bookId;
        Book = book;
    }
}
