using MediatR;
using QimiaLibrary.Business.Abstractions;
using QimiaLibrary.Business.Implementations.Commands.Workers;
using QimiaLibrary.Business.Implementations.Commands.Workers.WorkerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Handlers.Workers.Commands;

public class UpdateWorkerStatusCommandHandler : IRequestHandler<UpdateWorkerStatusCommand, Unit>
{
    private readonly IWorkerManager _workerManager;
    public UpdateWorkerStatusCommandHandler(IWorkerManager workerManager)
    {
        _workerManager = workerManager;
    }

    public async Task<Unit> Handle(UpdateWorkerStatusCommand request, CancellationToken cancellationToken)
    {
        if(request.Worker.WStatusId == 3)
        {
            throw new InvalidOperationException("To delete a worker use delete worker endpoint");
        }
        else
        {
            var worker = await _workerManager.GetWorkersByIdAsync(request.WorkerId, cancellationToken);

            worker.WStatusID = request.Worker.WStatusId;

            await _workerManager.UpdateWorkerAsync(worker, cancellationToken);

            return Unit.Value;
        }
    }
}
