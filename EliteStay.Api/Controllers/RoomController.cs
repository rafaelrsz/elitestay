using EliteStay.Domain.BookingContext.Commands.RoomCommands.Inputs;
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
  public class RoomController : Controller
  {
    private readonly IRoomRepository _repository;
    private readonly RoomHandler _handler;
    public RoomController(IRoomRepository repository, RoomHandler handler)
    {
      _repository = repository;
      _handler = handler;
    }


    /// <summary>
    /// Cria um quarto no sistema.
    /// </summary>
    [HttpPost]
    [Route("/rooms")]
    [Authorize(Roles = "Admin")]
    public object Post([FromBody] CreateRoomCommand command)
    {
      var result = _handler.Handle(command);

      if (_handler.Invalid || result is null)
        return BadRequest(_handler.Notifications);

      return (CreateRoomCommandResult)result;
    }


    /// <summary>
    /// Lista os quartos do sistema.
    /// </summary>
    [HttpGet]
    [Route("/rooms")]
    [AllowAnonymous]
    public List<ListRoomQueryResult> Get()
    {
      return _repository.Get().ToList();
    }

    /// <summary>
    /// Lista um quarto do sistema.
    /// </summary>
    [HttpGet]
    [Route("/rooms/{id}")]
    [AllowAnonymous]
    public ListRoomQueryResult Get(Guid id)
    {
      return _repository.Get(id);
    }

    /// <summary>
    /// Apaga um quarto do sistema.
    /// </summary>
    [HttpDelete]
    [Route("/rooms/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(Guid id)
    {
      if (this.Get(id).id == Guid.Empty)
      {
        return NotFound("Quarto não encontrado");
      }

      if (_repository.ValidateExclusion(id))
      {
        return NotFound("Usuario possui uma reserva cadastrada! Não é possível fazer a exclusão.");
      }

      _repository.Delete(id);
      return Ok("Quarto deletado com sucesso");
    }
  }
}