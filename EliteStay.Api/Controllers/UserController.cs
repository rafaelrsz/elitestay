using EliteStay.Domain.BookingContext.Commands.UserCommands.Inputs;
using EliteStay.Domain.BookingContext.Commands.UserCommands.Outputs;
using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Domain.BookingContext.Handlers;
using EliteStay.Domain.BookingContext.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EliteStay.Api.Controllers
{
  [Route("costumer")]
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
    [Route("")]
    public List<User> Get()
    {
      return null;
    }
    [HttpGet]
    [Route("/{id}")]
    public List<User> GetById(Guid id)
    {
      return null;
    }
    [HttpGet]
    [Route("/{id}")]
    public List<Book> GetBooks(Guid id)
    {
      return null;
    }

    [HttpPost]
    [Route("/user")]
    public object Post([FromBody] CreateUserCommand command)
    {
      var result = _handler.Handle(command);

      if (_handler.Invalid || result is null)
        return BadRequest(_handler.Notifications);

      return (CreateUserCommandResult)result;
    }

    [HttpPut]
    [Route("/{id}")]
    public User Delete(User user)
    {
      return null;
    }

    [HttpDelete]
    [Route("/{id}")]
    public User Delete(Guid id)
    {
      return null;
    }
  }
}