using MediatR;
using QimiaLibrary.Business.Implementations.Commands.Reservations.ReservationDtos;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Commands.Reservations;

public class ExtendReturnDateCommand : IRequest<Unit>
{
    public int ReservationId { get; }
    public ExtendReturnDateDto Reservation { get; set; }

    public ExtendReturnDateCommand(int reservationId, ExtendReturnDateDto reservation)
    {
        ReservationId = reservationId;
        Reservation = reservation;
    }
}
