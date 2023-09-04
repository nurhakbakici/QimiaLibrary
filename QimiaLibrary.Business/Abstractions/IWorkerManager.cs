using QimiaLibrary.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Abstractions;

public interface IWorkerManager
{
    public Task CreateWorkerAsync(Workers workers, CancellationToken cancellation);

    public Task<Workers> GetWorkersByIdAsync(int workerId, CancellationToken cancellationToken);

    public Task UpdateWorkerAsync(Workers workers, CancellationToken cancellationToken);

    public Task DeleteWorkerByIdAsync(int workerId, CancellationToken cancellationToken);

    public Task<IEnumerable<Workers>> GetAllWorkersAsync(CancellationToken cancellationToken);
}
