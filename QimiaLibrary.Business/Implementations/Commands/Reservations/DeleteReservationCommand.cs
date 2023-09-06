using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Commands.Reservations;

public class DeleteReservationCommand : IRequest<Unit>
{
    public int ReservationId { get;  }

    public DeleteReservationCommand(int reservationId)
    {
        ReservationId = reservationId;
    }
}
