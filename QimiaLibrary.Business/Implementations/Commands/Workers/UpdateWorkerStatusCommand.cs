using MediatR;
using QimiaLibrary.Business.Implementations.Commands.Workers.WorkerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Commands.Workers;

public class UpdateWorkerStatusCommand : IRequest<Unit>
{
    public int WorkerId { get; }
    public UpdateWorkerStatusDto Worker { get; set; }

    public UpdateWorkerStatusCommand(int workerId, UpdateWorkerStatusDto worker)
    {
        WorkerId = workerId;
        Worker = worker;
    }
}
