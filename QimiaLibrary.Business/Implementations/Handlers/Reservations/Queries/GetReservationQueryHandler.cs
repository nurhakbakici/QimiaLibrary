using AutoMapper;
using MediatR;
using QimiaLibrary.Business.Abstractions;
using QimiaLibrary.Business.Implementations.Queries.Reservations;
using QimiaLibrary.Business.Implementations.Queries.Reservations.ReservationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Handlers.Reservations.Queries;

public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, ReservationDto>
{
    private readonly IReservationManager _reservationManager;
    private readonly IMapper _mapper;

    public GetReservationQueryHandler(IReservationManager reservationManager, IMapper mapper)
    {
        _reservationManager = reservationManager;
        _mapper = mapper;
    }

    public async Task<ReservationDto> Handle(GetReservationQuery request, CancellationToken cancellationToken)
    {
        var reservation = await _reservationManager.GetReservationById(request.Id, cancellationToken);

        return _mapper.Map<ReservationDto>(reservation);
    }
}
