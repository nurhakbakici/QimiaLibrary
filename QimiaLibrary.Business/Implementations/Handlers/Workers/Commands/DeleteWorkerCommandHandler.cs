using MediatR;
using QimiaLibrary.Business.Abstractions;
using QimiaLibrary.Business.Implementations.Commands.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Handlers.Workers.Commands;

public class DeleteWorkerCommandHandler : IRequestHandler<DeleteWorkerCommand, Unit>
{
    private readonly IWorkerManager _workerManager;
    public DeleteWorkerCommandHandler(IWorkerManager workerManager)
    {
        _workerManager = workerManager;
    }

    public async Task<Unit> Handle(DeleteWorkerCommand request, CancellationToken cancellationToken)
    {
        var worker = await _workerManager.GetWorkersByIdAsync(request.WorkerId, cancellationToken);

        worker.WStatusID = 3;

        await _workerManager.UpdateWorkerAsync(worker, cancellationToken);

        return Unit.Value;
    }
}
