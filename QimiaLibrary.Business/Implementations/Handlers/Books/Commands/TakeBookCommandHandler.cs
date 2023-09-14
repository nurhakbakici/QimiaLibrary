using MediatR;
using QimiaLibrary.Business.Abstractions;
using QimiaLibrary.Business.Implementations.Commands.Books;
using QimiaLibrary.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Handlers.Books.Commands;

public class TakeBookCommandHandler : IRequestHandler<TakeBookCommand, int>
{
    private readonly IReservationManager _reservationManager;
    private readonly IBookManager _bookManager;

    public TakeBookCommandHandler(IReservationManager reservationManager, IBookManager bookManager)
    {
        _reservationManager = reservationManager;
        _bookManager = bookManager;
    }

    public async Task<int> Handle(TakeBookCommand request, CancellationToken cancellationToken)
    {
        var bookTaken = new DataAccess.Entities.Reservations
        {
            BookID = request.BookTaken.BookId,
            WorkerID = request.BookTaken.WorkerId,
            RStatusID = 2, // id 2 is obtained.
            ReservationDate = DateTime.Now,
            ReturnDate = DateTime.Now.AddDays(2 * 7)
        };

        var book = await _bookManager.GetBookByIdAsync(bookTaken.BookID, cancellationToken);

        if (book.BStatusID != 1) // if it is not on the shelf it cannot be reserved
        {
            throw new InvalidOperationException("books with a status other than 1 cannot be reserved");
        }
        else
        {
            book.BStatusID = 2; //reading
            book.Count -= 1;

            if (book.Count <= 0)
            {
                throw new InvalidOperationException("dont have enough books");
            }
            else
            {
                await _reservationManager.CreateReservationAsync(bookTaken, cancellationToken);
                await _bookManager.UpdateBookAsync(book, cancellationToken);

                return bookTaken.ReservationID;
            }
        }
    }
}
