using MediatR;
using QimiaLibrary.Business.Abstractions;
using QimiaLibrary.Business.Implementations.Commands.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Handlers.Workers.Commands;

public class UpdateWorkerCommandHandler : IRequestHandler<UpdateWorkerCommand, Unit>
{
    private readonly IWorkerManager _workerManager;

    public UpdateWorkerCommandHandler(IWorkerManager workerManager)
    {
        _workerManager = workerManager;
    }
    
    public async Task<Unit> Handle(UpdateWorkerCommand request, CancellationToken cancellationToken)
    {
        var worker = await _workerManager.GetWorkersByIdAsync(request.WorkerId, cancellationToken);

        worker.FirstMidName = request.Worker.FirstMidName;
        worker.LastName = request.Worker.LastName;

        await _workerManager.UpdateWorkerAsync(worker, cancellationToken);

        return Unit.Value;
    }
}
