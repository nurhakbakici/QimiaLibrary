using QimiaLibrary.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Abstractions;

public interface IReservationManager
{
    public Task CreateReservationAsync(Reservations reservations, CancellationToken cancellationToken);

    public Task<Reservations> GetReservationById(int reservationId, CancellationToken cancellationToken);

    public Task UpdateReservationAsync(Reservations reservations, CancellationToken cancellationToken);

    public Task DeleteReservationById(int reservationId, CancellationToken cancellationToken);

    public Task<IEnumerable<Reservations>> GetAllReservationsAsync(CancellationToken cancellationToken);
}
