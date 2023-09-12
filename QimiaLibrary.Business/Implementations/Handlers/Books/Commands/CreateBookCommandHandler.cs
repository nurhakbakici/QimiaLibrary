using MediatR;
using Microsoft.EntityFrameworkCore;
using QimiaLibrary.Business.Abstractions;
using QimiaLibrary.Business.Implementations.Commands.Books;
using QimiaLibrary.Business.Implementations.Commands.Workers;
using QimiaLibrary.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Handlers.Workers.Commands;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
    private readonly IBookManager _bookManager;

    public CreateBookCommandHandler(IBookManager bookManager)
    {
        _bookManager = bookManager;
    }

    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new DataAccess.Entities.Books
        {
            Title = request.Book.Title,
            Author = request.Book.Author,
            BStatusID = 1,
            Count = 1, 
        };

        await _bookManager.CreateBookAsync(book, cancellationToken);

        return book.BookID;

    }
}