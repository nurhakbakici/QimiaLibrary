using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Commands.Workers;

public class UpdateWorkerStatusCommand : IRequest<Unit>
{
    public int WorkerId { get; }
    public UpdateWorkerStatusCommand Worker { get; set; }

    public UpdateWorkerStatusCommand(int workerId, UpdateWorkerStatusCommand worker)
    {
        WorkerId = workerId;
        Worker = worker;
    }
}
