using EliteStay.Domain.BookingContext.Commands.BookCommands.Inputs;
using EliteStay.Domain.BookingContext.Commands.BookCommands.Outputs;
using EliteStay.Domain.BookingContext.Commands.UserCommands.Inputs;
using EliteStay.Domain.BookingContext.Commands.UserCommands.Outputs;
using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Domain.BookingContext.Handlers;
using EliteStay.Domain.BookingContext.Queries;
using EliteStay.Domain.BookingContext.Repositories;
using EliteStay.Shared.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EliteStay.Api.Controllers
{
  public class BookController : Controller
  {
    private readonly IBookRepository _repository;
    private readonly BookHandler _handler;

    public BookController(IBookRepository repository, BookHandler handler)
    {
      _repository = repository;
      _handler = handler;
    }

    /// <summary>
    /// Cria uma reserva de um quarto no sistema
    /// </summary>
    [HttpPost]
    [Route("/books")]
    [Authorize]
    public object BookRoom([FromBody] CreateBookRoomCommand command)
    {
      var result = _handler.Handle(command);

      if (_handler.Invalid || result is null)
        return BadRequest(_handler.Notifications);

      return (CreateBookRoomCommandResult)result;
    }

    /// <summary>
    /// Muda o status de uma reserva para cancelado
    /// </summary>
    [HttpPatch]
    [Route("/books/{id}/cancel")]
    [Authorize]
    public void CancelBook(Guid id)
    {
      _repository.UpdateStatus(id, Domain.BookingContext.Enums.EBookStatus.Canceled);
    }

    /// <summary>
    /// Muda o status de uma reserva para finalizado
    /// </summary>
    [HttpPatch]
    [Route("/books/{id}/finish")]
    [Authorize]
    public void FinishBook(Guid id)
    {
      _repository.UpdateStatus(id, Domain.BookingContext.Enums.EBookStatus.Finished);
    }

    /// <summary>
    /// Lista as reservas do sistema.
    /// </summary>
    [HttpGet]
    [Route("/books")]
    [Authorize]
    public List<ListBookQueryResult> Get()
    {
      return _repository.Get().ToList();
    }

    /// <summary>
    /// Retorna uma determinada reserva
    /// </summary>
    [HttpGet]
    [Route("/books/{id}")]
    [Authorize]
    public ListBookQueryResult? Get(Guid id)
    {
      var response = _repository.Get(id);
      if (response.id == Guid.Empty)
        return null;

      return response;
    }

    /// <summary>
    /// Lista as reservas de um determinado usuário.
    /// </summary>
    [HttpGet]
    [Route("/users/{userId}/books")]
    [Authorize]
    public List<ListBookQueryResult> GetBooksByUser(Guid userId)
    {
      return _repository.GetByUser(userId).ToList();
    }

    /// <summary>
    /// Lista as reservas de um determinado quarto.
    /// </summary>
    [HttpGet]
    [Route("/rooms/{roomId}/books")]
    [Authorize]
    public List<ListBookQueryResult> GetBooksByRoom(Guid roomId)
    {
      return _repository.GetByRoom(roomId).ToList();
    }
  }
}