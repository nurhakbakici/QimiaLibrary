using QimiaLibrary.Business.Abstractions;
using QimiaLibrary.DataAccess.Entities;
using QimiaLibrary.DataAccess.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations;

public class BookManager : IBookManager
{
    private readonly IBookRepository _bookRepository;
    public BookManager(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public Task CreateBookAsync(Books book, CancellationToken cancellationToken)
    {
        return _bookRepository.CreateAsync(book, cancellationToken);
    }

    public Task<Books> GetBookByIdAsync(int bookId, CancellationToken cancellationToken)
    {
        return _bookRepository.GetByIdAsync(bookId, cancellationToken);
    }

    public Task DeleteBookbyIdAsync(int bookId, CancellationToken cancellationToken)
    {
        return _bookRepository.DeleteByIdAsync(bookId, cancellationToken);
    }

    public Task UpdateBookAsync(Books book, CancellationToken cancellationToken)
    {
        return _bookRepository.UpdateAsync(book, cancellationToken);
    } 

    public Task<IEnumerable<Books>> GetAllBooksAsync(CancellationToken cancellationToken)
    {
        return _bookRepository.GetAllAsync(cancellationToken);
    }

    public Task DeleteBookByIdAsync(int bookId, CancellationToken cancellationToken)
    {
        return _bookRepository.DeleteByIdAsync(bookId, cancellationToken);
    }
}
