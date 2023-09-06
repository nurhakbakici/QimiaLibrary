using MediatR;
using QimiaLibrary.Business.Implementations.Queries.Workers.WorkerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Queries.Workers;

public class GetWorkerQuery : IRequest<WorkerDto>
{
    public int Id { get; }

    public GetWorkerQuery(int id)
    {
        Id = id;
    }
}
