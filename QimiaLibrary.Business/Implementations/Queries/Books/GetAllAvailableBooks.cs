using MediatR;
using QimiaLibrary.Business.Implementations.Queries.Books.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Queries.Books;

public class GetAllAvailableBooks : IRequest<BookDto>
{
    public DateTime CurrentTime{ get; set; }

    public GetAllAvailableBooks(DateTime currentTime)
    {
        CurrentTime = currentTime;
    }
}
