using MediatR;
using QimiaLibrary.Business.Implementations.Commands.Reservations.ReservationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Commands.Reservations;

public class UpdateReservationCommand : IRequest<Unit>
{
    public int ReservationId { get; }
    public UpdateReservationDto Reservation { get; set; }

    public UpdateReservationCommand(int reservationId, UpdateReservationDto reservation)
    {
        ReservationId = reservationId;
        Reservation = reservation;
    }
}
