using AutoMapper.Configuration.Annotations;
using MediatR;
using QimiaLibrary.Business.Abstractions;
using QimiaLibrary.Business.Implementations.Commands.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Handlers.Reservations.Commands;

public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, Unit>
{
    private readonly IReservationManager _reservationManager;
    private readonly IBookManager _bookManager;
    public DeleteReservationCommandHandler(IReservationManager reservationManager, IBookManager bookManager)
    {
        _reservationManager = reservationManager;
        _bookManager = bookManager;
    }

    public async Task<Unit> Handle(DeleteReservationCommand request,CancellationToken cancellationToken)
    {
        var reservation = await _reservationManager.GetReservationById(request.ReservationId, cancellationToken);
        var book = await _bookManager.GetBookByIdAsync(reservation.BookID, cancellationToken);

        reservation.RStatusID = 2; // inactive
        book.BStatusID = 1; // on the shelf

        await _reservationManager.UpdateReservationAsync(reservation, cancellationToken);
        await _bookManager.UpdateBookAsync(book, cancellationToken);
        

        return Unit.Value;
    }
}
