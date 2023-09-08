using MediatR;
using QimiaLibrary.Business.Implementations.Commands.Workers.WorkerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Commands.Workers;

public class DeleteWorkerCommand : IRequest<Unit>
{
    public int WorkerId { get; }

    public DeleteWorkerCommand(int workerId)
    {
        WorkerId = workerId;
    }
}
