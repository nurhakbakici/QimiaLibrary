using MediatR;
using Microsoft.AspNetCore.Mvc;
using QimiaLibrary.Business.Implementations.Commands.Workers.WorkerDtos;
using QimiaLibrary.Business.Implementations.Commands.Workers;
using QimiaLibrary.Business.Implementations.Queries.Workers.WorkerDtos;
using QimiaLibrary.Business.Implementations.Queries.Workers;
using QimiaLibrary.Business.Implementations.Commands.Books.BookDtos;
using QimiaLibrary.Business.Implementations.Commands.Books;
using QimiaLibrary.Business.Implementations.Queries.Books.BookDtos;
using QimiaLibrary.Business.Implementations.Queries.Books;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using QimiaLibrary.Business.Implementations.Commands.Reservations.ReservationDtos;
using QimiaLibrary.Business.Implementations.Commands.Reservations;
using QimiaLibrary.Business.Implementations.Queries.Reservations;
using Microsoft.AspNetCore.ResponseCompression;
using QimiaLibrary.Business.Implementations.Queries.Reservations.ReservationDtos;
using Microsoft.AspNetCore.Authorization;

namespace QimiaLibrary.Controllers;

[ApiController]
[Authorize]
[Route("[Controller]")]

public class BookController : Controller
{
    private readonly IMediator _mediator;
    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> CreateBook(
        [FromBody] CreateBookDto book,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new CreateBookCommand(book), cancellationToken);

        return CreatedAtAction(
            nameof(GetBook),
            new { Id = response },
            book);
    }

    [HttpGet("{id}")]
    public Task<BookDto> GetBook(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        return _mediator.Send(
            new GetBookQuery(id),
            cancellationToken);
    }

    [HttpGet]
    public Task<List<BookDto>> GetBooks(CancellationToken cancellationToken)
    {
        return _mediator.Send(
            new GetBooksQuery(),
            cancellationToken);
    }

    [HttpGet("availableBooks")]
    public Task<List<BookDto>> GetAvailableBooks(CancellationToken cancellationToken)
    {
        return _mediator.Send(
            new GetAvailableBooksQuery(),
            cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBook(
      [FromRoute] int id,
      [FromBody] UpdateBookDto book,
      CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new UpdateBookCommand(id, book), cancellationToken);

        return NoContent();
    }

    [HttpPut("{id}/updateCount")]
    public async Task<ActionResult> UpdateBookCount(
        [FromRoute] int id,
        [FromBody] UpdateBookCountDto book,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new UpdateBookCountCommand(id, book), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBook(
       [FromRoute] int id,
       CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new DeleteBookCommand(id), cancellationToken);

        return NoContent();
    }

    [HttpPost("takeBook")]
    public async Task<ActionResult> TakeBook(
        [FromBody] CreateReservationDto reservation,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new TakeBookCommand(reservation), cancellationToken);

        return CreatedAtAction(
            nameof(GetReservation),
            new { Id = response },
            reservation);
    }

    [HttpGet("{id}/takeBookReservation")]
    public Task<ReservationDto> GetReservation(
       [FromRoute] int id,
       CancellationToken cancellationToken)
    {
        return _mediator.Send(
            new GetReservationQuery(id),
            cancellationToken);
    }
}
