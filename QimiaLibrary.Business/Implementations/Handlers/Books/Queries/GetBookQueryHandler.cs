using AutoMapper;
using MediatR;
using QimiaLibrary.Business.Abstractions;
using QimiaLibrary.Business.Implementations.Queries.Books;
using QimiaLibrary.Business.Implementations.Queries.Books.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Handlers.Books.Queries;

public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookDto> 
{
    private readonly IBookManager _bookManager;
    private readonly IMapper _mapper;

    public GetBookQueryHandler(IBookManager bookManager, IMapper mapper)
    {
        _bookManager = bookManager;
        _mapper = mapper;
    }

    public async Task<BookDto> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        var book = await _bookManager.GetBookByIdAsync(request.Id, cancellationToken);

        return _mapper.Map<BookDto>(book);
    }
}
