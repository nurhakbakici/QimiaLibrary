using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QimiaLibrary.Business.Implementations.Commands.Workers;
using QimiaLibrary.Business.Implementations.Commands.Workers.WorkerDtos;
using QimiaLibrary.Business.Implementations.Queries.Workers;
using QimiaLibrary.Business.Implementations.Queries.Workers.WorkerDtos;

namespace QimiaLibrary.Controllers;


[ApiController]
[Authorize]
[Route("[Controller]")]


public class WorkersController : Controller
{
    private readonly IMediator _mediator;
    public WorkersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> CreateWorker(
        [FromBody] CreateWorkerDto worker,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new CreateWorkerCommand(worker), cancellationToken);

        return CreatedAtAction(
            nameof(GetWorker),
            new { Id = response },
            worker);
    }

    [HttpGet("{id}")]
    public Task<WorkerDto> GetWorker(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        return _mediator.Send(
            new GetWorkerQuery(id),
            cancellationToken);
    }

    [HttpGet]
    public Task<List<WorkerDto>> GetWorkers(CancellationToken cancellationToken)
    {
        return _mediator.Send(
            new GetWorkersQuery(), cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateWorker(
        [FromRoute] int id,
        [FromBody] UpdateWorkerDto worker,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new UpdateWorkerCommand(id, worker), cancellationToken);

        return NoContent();
    }

    [HttpPut("{id}/statusUpdate")]
    public async Task<ActionResult> UpdateWorkerStatus(
        [FromRoute] int id,
        [FromBody] UpdateWorkerStatusDto worker,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new UpdateWorkerStatusCommand(id, worker), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteWorker(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new DeleteWorkerCommand(id), cancellationToken);

        return NoContent();
    }
}
