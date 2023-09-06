using MediatR;
using QimiaLibrary.Business.Implementations.Queries.Reservations.ReservationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Queries.Reservations;

public class GetReservationQuery : IRequest<ReservationDto>
{
    public int Id { get;  }
    
    public GetReservationQuery(int id)
    {
        Id = id;
    }
}
