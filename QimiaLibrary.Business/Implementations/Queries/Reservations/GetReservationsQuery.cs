using MediatR;
using QimiaLibrary.Business.Implementations.Queries.Reservations.ReservationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Queries.Reservations;

public class GetReservationsQuery : IRequest<List<ReservationDto>>
{
}
