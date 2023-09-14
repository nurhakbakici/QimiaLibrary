using MediatR;
using QimiaLibrary.Business.Implementations.Commands.Reservations.ReservationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Commands.Books;

public class TakeBookCommand : IRequest<int>
{
    public CreateReservationDto BookTaken { get; set; }

    public TakeBookCommand(CreateReservationDto bookTaken)
    {
       BookTaken  = bookTaken;
    }
}
