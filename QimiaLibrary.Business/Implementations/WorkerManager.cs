using QimiaLibrary.Business.Abstractions;
using QimiaLibrary.DataAccess.Entities;
using QimiaLibrary.DataAccess.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations;

public class WorkerManager : IWorkerManager
{
    private readonly IWorkerRepository _workerRepository;

    public WorkerManager(IWorkerRepository workerRepository)
    {
        _workerRepository = workerRepository;
    }

    public Task CreateWorkerAsync(Workers workers, CancellationToken cancellation)
    {
        workers.WorkerID = default;
        return _workerRepository.CreateAsync(workers, cancellation);
    }

    public Task DeleteWorkerByIdAsync(int workerId, CancellationToken cancellationToken)
    {
        return _workerRepository.DeleteByIdAsync(workerId, cancellationToken);
    }

    public Task<IEnumerable<Workers>> GetAllWorkersAsync(CancellationToken cancellationToken)
    {
        return _workerRepository.GetAllAsync(cancellationToken);
    }

    public Task<Workers> GetWorkersByIdAsync(int workerId, CancellationToken cancellationToken)
    {
        return _workerRepository.GetByIdAsync(workerId, cancellationToken);
    }

    public Task UpdateWorkerAsync(Workers workers, CancellationToken cancellationToken)
    {
        return _workerRepository.UpdateAsync(workers, cancellationToken);
    }
}
