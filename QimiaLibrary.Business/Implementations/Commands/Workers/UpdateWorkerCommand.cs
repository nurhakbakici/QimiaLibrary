using MediatR;
using QimiaLibrary.Business.Implementations.Commands.Workers.WorkerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Commands.Workers;

public class UpdateWorkerCommand : IRequest<Unit>
{
    public int WorkerId { get; }
    public UpdateWorkerDto Worker { get; set; }

    public UpdateWorkerCommand(int workerId, UpdateWorkerDto worker)
    {
        WorkerId = workerId;
        Worker = worker;
    }
}
