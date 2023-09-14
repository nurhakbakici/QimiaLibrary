using MediatR;
using QimiaLibrary.Business.Abstractions;
using QimiaLibrary.Business.Implementations.Commands.Reservations;
using QimiaLibrary.DataAccess.Entities;
using QimiaLibrary.DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Handlers.Reservations.Commands;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, int>
{
    private readonly IReservationManager _reservationManager;
    private readonly IBookManager _bookManager;

    public CreateReservationCommandHandler(IReservationManager reservationManager, IBookManager bookManager)
    {
        _reservationManager = reservationManager;
        _bookManager = bookManager;
    }

    public async Task<int> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = new DataAccess.Entities.Reservations
        {
            BookID = request.Reservation.BookId,
            WorkerID = request.Reservation.WorkerId,
            RStatusID = 1, // id 1 is active and 2 is inactive
            ReservationDate = DateTime.Now,
            ReturnDate = DateTime.Now.AddDays(2 * 7)
        };

        var book = await _bookManager.GetBookByIdAsync(reservation.BookID, cancellationToken);

        if (book.BStatusID != 1) // if it is not on the shelf it cannot be reserved
        {
            throw new InvalidOperationException("books with a status other than 1 cannot be reserved");
        }
        else
        {
            book.BStatusID = 3; //booked
            book.Count -= 1;

            if(book.Count == 0)
            {
                throw new InvalidOperationException("dont have enough books");
            }
            else
            {
                await _reservationManager.CreateReservationAsync(reservation, cancellationToken);
                await _bookManager.UpdateBookAsync(book, cancellationToken);

                return reservation.ReservationID;
            } 
        }
    }
}
