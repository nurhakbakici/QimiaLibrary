using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using QimiaLibrary.Business.Implementations.Commands.Books.BookDtos;
using QimiaLibrary.Business.Implementations.Commands.Books;
using QimiaLibrary.Business.Implementations.Commands.Reservations.ReservationDtos;
using QimiaLibrary.Business.Implementations.Commands.Reservations;
using QimiaLibrary.Business.Implementations.Queries.Books.BookDtos;
using QimiaLibrary.Business.Implementations.Queries.Books;
using QimiaLibrary.Business.Implementations.Queries.Reservations.ReservationDtos;
using QimiaLibrary.Business.Implementations.Queries.Reservations;
using QimiaLibrary.Business.Implementations.Commands.Workers.WorkerDtos;
using QimiaLibrary.Business.Implementations.Commands.Workers;

namespace QimiaLibrary.Controllers;


[ApiController]
[Route("[Controller]")]

public class ReservationsController : Controller
{
    private readonly IMediator _mediator;

    public ReservationsController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    public async Task<ActionResult> CreateReservation(
        [FromBody] CreateReservationDto reservation,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new CreateReservationCommand(reservation), cancellationToken);

        return CreatedAtAction(
            nameof(GetReservation),
            new { Id = response },
            reservation);
    }

    [HttpGet("{id}")]
    public Task<ReservationDto> GetReservation(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        return _mediator.Send(
            new GetReservationQuery(id),
            cancellationToken);
    }

    [HttpGet]
    public Task<List<ReservationDto>> GetReservations(CancellationToken cancellationtoken)
    {
        return _mediator.Send(
            new GetReservationsQuery(), cancellationtoken);
    }


    [HttpPut("id")]
    public async Task<ActionResult> ExtendReturnDate(
        [FromRoute] int id,
        [FromBody] ExtendReturnDateDto reservation,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new ExtendReturnDateCommand(id, reservation), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteReservation(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new DeleteReservationCommand(id), cancellationToken);

        return NoContent();
    }
}
