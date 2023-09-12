using MediatR;
using QimiaLibrary.Business.Implementations.Commands.Books.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Commands.Books;

public class CreateBookCommand : IRequest<int>
{
    public CreateBookDto Book { get; set; }

    public CreateBookCommand(CreateBookDto book)
    {
        Book = book;
    }
}
