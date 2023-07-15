using EliteStay.Domain.BookingContext.Commands.UserCommands.Inputs;
using EliteStay.Domain.BookingContext.Commands.UserCommands.Outputs;
using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Domain.BookingContext.Enums;
using EliteStay.Domain.BookingContext.Repositories;
using EliteStay.Domain.BookingContext.Services;
using EliteStay.Domain.BookingContext.Utils;
using EliteStay.Domain.BookingContext.ValueObjects;
using EliteStay.Shared.Commands;
using FluentValidator;

namespace EliteStay.Domain.BookingContext.Handlers
{
  public class UserHandler : Notifiable, ICommandHandler<CreateUserCommand>
  {
    private readonly IUserRepository _repository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenService _tokenService;
    public UserHandler(IUserRepository repository, IPasswordHasher passwordHasher, ITokenService tokenService)
    {
      _repository = repository;
      _passwordHasher = passwordHasher;
      _tokenService = tokenService;
    }
    public ICommandResult? Handle(CreateUserCommand command)
    {
      if (_repository.CheckDocument(command.document))
      {
        AddNotification("Document", "Este CPF já está em uso");
      }

      if (_repository.CheckEmail(command.email))
      {
        AddNotification("Email", "Este Email já está em uso");
      }

      var name = new Name(command.firstName, command.lastName);
      var email = new Email(command.email);
      var document = new Document(command.document);

      if (!Enum.IsDefined(typeof(EUserPermission), command.permission))
      {
        AddNotification("Permission", "Permissão do usuário inválida");
        command.permission = EUserPermission.Normal;
      }

      command.password = _passwordHasher.Hash(command.password);

      var user = new User(name, command.password, email, document,
                          command.phone, command.age,
                          (EUserPermission)command.permission);

      AddNotifications(name.Notifications);
      AddNotifications(document.Notifications);
      AddNotifications(email.Notifications);
      AddNotifications(user.Notifications);

      if (Invalid)
        return new CommandResult(
            false,
            "Por favor, corrija os campos abaixo",
            Notifications);

      _repository.Save(user);

      return new CreateUserCommandResult(user.Id,
        name.FirstName,
        name.LastName,
        email.Address,
        document.Number,
        user.phone,
        user.age,
        command.permission.ToString());
    }

    public ICommandResult? Handle(AuthenticateUserCommand command)
    {

      var email = new Email(command.email);
      if (!_repository.CheckEmail(command.email))
        AddNotification("Email", "Email não encontrado");

      if (Invalid)
        return new CommandResult(
            false,
            "Entrada invalida",
            Notifications);

      var user = _repository.Get(email);

      var sucess = _passwordHasher.Verify(user.password, command.password);

      if (!sucess)
        AddNotification("Credentials", "Email ou senha incorretos");

      if (Invalid)
        return new CommandResult(
            false,
            "Entrada invalida",
            Notifications);

      var userEntity = new User(user.id, null!, null!, null!, user.permission);

      var token = _tokenService.GenerateToken(userEntity);

      return new AuthenticateUserCommandResult(token, user.email);
    }
  }
}