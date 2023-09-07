using AutoMapper;
using MediatR;
using QimiaLibrary.Business.Abstractions;
using QimiaLibrary.Business.Implementations.Queries.Workers;
using QimiaLibrary.Business.Implementations.Queries.Workers.WorkerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.Implementations.Handlers.Workers.Queries;

public class GetWorkersQueryHandler : IRequestHandler<GetWorkersQuery, List<WorkerDto>>
{
    private readonly IWorkerManager _workerManager;
    private readonly IMapper _mapper;

    public GetWorkersQueryHandler(IWorkerManager workerManager, IMapper mapper)
    {
        _workerManager = workerManager;
        _mapper = mapper;
    }

    public async Task<List<WorkerDto>> Handle(GetWorkersQuery request, CancellationToken cancellationToken)
    {
        var workers = await _workerManager.GetAllWorkersAsync(cancellationToken);

        var availableWorkers = workers.Where(w => w.WStatusID == 1 ||  w.WStatusID == 2);

        return workers.Select(w => _mapper.Map<WorkerDto>(w)).ToList();
    }
}

