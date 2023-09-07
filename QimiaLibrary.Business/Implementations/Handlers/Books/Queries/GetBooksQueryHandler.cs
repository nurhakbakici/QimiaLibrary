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
 
public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, List<BookDto>>
{
    private readonly IBookManager _bookManager;
    private readonly IMapper _mapper;

    public GetBooksQueryHandler(IBookManager bookManager, IMapper mapper)
    {
        _bookManager = bookManager;
        _mapper = mapper;
    }

    public async Task<List<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookManager.GetAllBooksAsync(cancellationToken);

        return books.Select(b => _mapper.Map<BookDto>(b)).ToList();
    }
}
