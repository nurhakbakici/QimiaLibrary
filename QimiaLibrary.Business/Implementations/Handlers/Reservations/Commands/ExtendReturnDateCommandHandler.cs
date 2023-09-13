using MediatR;
using QimiaLibrary.Business.Abstractions;
using QimiaLibrary.Business.Implementations.Commands.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Handlers.Reservations.Commands;

public class ExtendReturnDateCommandHandler : IRequestHandler<ExtendReturnDateCommand, Unit>
{
    private readonly IReservationManager _reservationManager;
    public ExtendReturnDateCommandHandler(IReservationManager reservationManager)
    {
        _reservationManager = reservationManager;
    }

    public async Task<Unit> Handle(ExtendReturnDateCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _reservationManager.GetReservationById(request.ReservationId, cancellationToken);

        reservation.ReturnDate = request.Reservation.ReturnDate.AddDays(2 * 7);

        await _reservationManager.UpdateReservationAsync(reservation, cancellationToken);

        return Unit.Value;
    }
}
