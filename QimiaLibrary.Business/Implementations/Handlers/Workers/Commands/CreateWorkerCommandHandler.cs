using MediatR;
using QimiaLibrary.Business.Abstractions;
using QimiaLibrary.Business.Implementations.Commands.Workers;
using QimiaLibrary.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Handlers.Workers.Commands;

public class CreateWorkerCommandHandler : IRequestHandler<CreateWorkerCommand, int>
{
    private readonly IWorkerManager _workerManager;

    public CreateWorkerCommandHandler(IWorkerManager workerManager)
    {
        _workerManager = workerManager;
    }

    public async Task<int> Handle(CreateWorkerCommand request, CancellationToken cancellationToken)
    {
        var worker = new DataAccess.Entities.Workers
        {
            FirstMidName = request.Worker.FirstMidName,
            LastName = request.Worker.LastName,
            WStatusID = request.Worker.WStatusId,
        };

        await _workerManager.CreateWorkerAsync(worker, cancellationToken);

        return worker.WorkerID;

    }
}