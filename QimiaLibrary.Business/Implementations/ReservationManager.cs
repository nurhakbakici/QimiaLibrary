using Microsoft.EntityFrameworkCore.Metadata;
using QimiaLibrary.Business.Abstractions;
using QimiaLibrary.DataAccess.Entities;
using QimiaLibrary.DataAccess.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations;

public class ReservationManager : IReservationManager
{
    private readonly IReservationRepository _reservationRepository;

    public ReservationManager(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public Task CreateReservationAsync(Reservations reservation, CancellationToken cancellationToken)
    {
        reservation.ReservationID = default;
        return _reservationRepository.CreateAsync(reservation, cancellationToken);
    }

    public Task DeleteReservationById(int reservationId, CancellationToken cancellationToken)
    {
        return _reservationRepository.DeleteByIdAsync(reservationId, cancellationToken);
    }

    public Task<IEnumerable<Reservations>> GetAllReservationsAsync(CancellationToken cancellationToken)
    {
        return _reservationRepository.GetAllAsync(cancellationToken);
    }

    public Task<Reservations> GetReservationById(int reservationId, CancellationToken cancellationToken)
    {
        return _reservationRepository.GetByIdAsync(reservationId, cancellationToken);
    }

    public Task UpdateReservationAsync(Reservations reservations, CancellationToken cancellationToken)
    {
        return _reservationRepository.UpdateAsync(reservations, cancellationToken);
    }
}
