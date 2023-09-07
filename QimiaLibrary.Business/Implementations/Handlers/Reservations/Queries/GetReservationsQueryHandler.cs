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

public class GetReservationsQueryHandler : IRequestHandler<GetReservationsQuery, List<ReservationDto>>
{
    private readonly IReservationManager _reservationManager;
    private readonly IMapper _mapper;

    public GetReservationsQueryHandler(IReservationManager reservationManager, IMapper mapper)
    {
        _reservationManager = reservationManager;
        _mapper = mapper;
    }

    public async Task<List<ReservationDto>> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
    {
        var reservations = await _reservationManager.GetAllReservationsAsync(cancellationToken);

        return reservations.Select(r => _mapper.Map<ReservationDto>(r)).ToList();
    }
}
