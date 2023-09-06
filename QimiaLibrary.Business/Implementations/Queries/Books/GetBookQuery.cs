using MediatR;
using QimiaLibrary.Business.Implementations.Queries.Books.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Queries.Books;

public class GetBookQuery : IRequest<BookDto>
{
    public int Id { get; }

    public GetBookQuery(int id)
    {
        Id = id;
    }
}
