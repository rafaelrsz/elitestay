using EliteStay.Domain.BookingContext.Commands.UserCommands.Inputs;
using EliteStay.Domain.BookingContext.Commands.UserCommands.Outputs;
using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Domain.BookingContext.Handlers;
using EliteStay.Domain.BookingContext.Queries;
using EliteStay.Domain.BookingContext.Repositories;
using EliteStay.Shared.Commands;
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

    [HttpPost]
    [Route("/rooms")]
    public object Post([FromBody] CreateRoomCommand command)
    {
      var result = _handler.Handle(command);

      if (_handler.Invalid || result is null)
        return BadRequest(_handler.Notifications);

      return (CreateRoomCommandResult)result;
    }

    [HttpGet]
    [Route("/rooms")]
    public List<ListRoomQueryResult> Get()
    {
      return _repository.Get().ToList();
    }

    [HttpGet]
    [Route("/rooms/{id}")]
    public ListRoomQueryResult Get(Guid id)
    {
      return _repository.Get(id);
    }

    [HttpDelete]
    [Route("/rooms/{id}")]
    public IActionResult Delete(Guid id)
    {
      if (this.Get(id).id == Guid.Empty)
      {
        return NotFound("Quarto não encontrado");
      }

      _repository.Delete(id);
      return Ok("Quarto deletado com sucesso");
    }
  }
}