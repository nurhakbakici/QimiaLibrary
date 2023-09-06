using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Queries.Books.BookDtos;

public class BookDto
{
    public int BookID { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int Count { get; set; }
    public int BStatusID { get; set; }
}
