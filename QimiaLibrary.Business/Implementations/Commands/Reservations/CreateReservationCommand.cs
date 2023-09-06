using MediatR;
using QimiaLibrary.Business.Implementations.Commands.Reservations.ReservationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Commands.Reservations;

public class CreateReservationCommand : IRequest<int>
{
    public CreateReservationDto CreateReservationDto { get; set; }

    public CreateReservationCommand(CreateReservationDto reservation)
    {
        CreateReservationDto = reservation;
    }
}
