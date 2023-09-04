using QimiaLibrary.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Abstractions;

public interface IBookManager
{
    public Task CreateBookAsync(Books book, CancellationToken cancellationToken);

    public Task<Books> GetBookByIdAsync(int bookId, CancellationToken cancellationToken);

    public Task UpdateBookAsync(Books books, CancellationToken cancellationToken);

    public Task DeleteBookByIdAsync(int bookId, CancellationToken cancellationToken);

    public Task<IEnumerable<Books>> GetAllBooksAsync(CancellationToken cancellationToken);
}
