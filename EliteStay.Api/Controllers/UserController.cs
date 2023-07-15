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
  public class UserController : Controller
  {
    private readonly IUserRepository _repository;
    private readonly UserHandler _handler;
    public UserController(IUserRepository repository, UserHandler handler)
    {
      _repository = repository;
      _handler = handler;
    }

    /// <summary>
    /// Lista os usuários do sistema.
    /// </summary>
    [HttpGet]
    [Route("/users")]
    [Authorize(Roles = "Admin")]
    public List<ListUsersQueryResult> Get()
    {
      return _repository.Get().ToList();
    }

    /// <summary>
    /// Lista um usuário do sistema.
    /// </summary>
    [HttpGet]
    [Route("/users/{id}")]
    [Authorize(Roles = "Admin")]
    public ListUsersQueryResult GetById(Guid id)
    {
      return _repository.Get(id);
    }

    /// <summary>
    /// Cria um usuário.
    /// </summary>
    [HttpPost]
    [Route("/users")]
    [AllowAnonymous]
    public IActionResult Post([FromBody] CreateUserCommand command)
    {
      var result = _handler.Handle(command);

      if (_handler.Invalid || result is null)
        return BadRequest(_handler.Notifications);

      return Ok(result);
    }

    /// <summary>
    /// Apaga um usuário do sistema.
    /// </summary>
    [HttpDelete]
    [Route("/users/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(Guid id)
    {
      if (this.GetById(id).id == Guid.Empty)
      {
        return NotFound("Usuario não encontrado");
      }

      if (_repository.ValidateExclusion(id))
      {
        return NotFound("Usuario possui uma reserva cadastrada! Não é possível fazer a exclusão.");
      }

      _repository.Delete(id);
      return Ok("Usuario deletado com sucesso");
    }

    /// <summary>
    /// Gera o token de autenticação do usuário.
    /// </summary>
    [HttpPost]
    [Route("/authenticate")]
    [AllowAnonymous]
    public IActionResult Authenticate([FromBody] AuthenticateUserCommand command)
    {
      var result = _handler.Handle(command);

      if (_handler.Invalid || result is null)
        return BadRequest(_handler.Notifications);

      return Ok(result);
    }
  }
}