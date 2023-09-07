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

public class GetWorkerQueryHandler : IRequestHandler<GetWorkerQuery, WorkerDto>
{
    private readonly IWorkerManager _workerManager;
    private readonly IMapper _mapper;

    public GetWorkerQueryHandler(
        IWorkerManager workerManager,
        IMapper mapper)
    {
        _workerManager = workerManager;
        _mapper = mapper;
    }

    public async Task<WorkerDto> Handle(GetWorkerQuery request, CancellationToken cancellationToken)
    {
        var worker = await _workerManager.GetWorkersByIdAsync(request.Id, cancellationToken);
        
        return _mapper.Map<WorkerDto>(worker);
    }
}
