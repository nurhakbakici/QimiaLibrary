using AutoMapper;
using MediatR;
using QimiaLibrary.Business.Abstractions;
using QimiaLibrary.Business.Implementations.Queries.Books;
using QimiaLibrary.Business.Implementations.Queries.Books.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Handlers.Books.Queries;

public class GetAvailableBooksQueryHandler : IRequestHandler<GetAvailableBooksQuery, List<BookDto>>
{
    private readonly IBookManager _bookManager;
    private readonly IMapper _mapper;

    public GetAvailableBooksQueryHandler(IBookManager bookManager, IMapper mapper)
    {
        _bookManager = bookManager;
        _mapper = mapper;
    }

    public async Task<List<BookDto>> Handle(GetAvailableBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookManager.GetAllBooksAsync(cancellationToken);

        var availableBooks = books.Where(b => b.BStatusID == 1 && b.Count >= 0);

        return availableBooks.Select(b => _mapper.Map<BookDto>(b)).ToList();
    }
}
