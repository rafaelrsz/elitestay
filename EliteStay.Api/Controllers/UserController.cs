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
  public class UserController : Controller
  {
    private readonly IUserRepository _repository;
    private readonly UserHandler _handler;
    public UserController(IUserRepository repository, UserHandler handler)
    {
      _repository = repository;
      _handler = handler;
    }

    [HttpGet]
    [Route("/users")]
    public List<ListUsersQueryResult> Get()
    {
      return _repository.Get().ToList();
    }
    [HttpGet]
    [Route("/users/{id}")]
    public ListUsersQueryResult GetById(Guid id)
    {
      return _repository.Get(id);
    }
    [HttpGet]
    [Route("/users/{id}/books")]
    public List<Book> GetBooks(Guid id)
    {
      return null;
    }

    [HttpPost]
    [Route("/users")]
    public object Post([FromBody] CreateUserCommand command)
    {
      var result = _handler.Handle(command);

      if (_handler.Invalid || result is null)
        return BadRequest(_handler.Notifications);

      return (CreateUserCommandResult)result;
    }

    [HttpDelete]
    [Route("/users/{id}")]
    public IActionResult Delete(Guid id)
    {
      if (this.GetById(id).id == Guid.Empty)
      {
        return NotFound("Usuario não encontrado");
      }

      _repository.Delete(id);
      return Ok("Usuario deletado com sucesso");
    }
  }
}