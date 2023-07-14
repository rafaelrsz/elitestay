using EliteStay.Domain.BookingContext.Commands.UserCommands.Inputs;
using EliteStay.Domain.BookingContext.Commands.UserCommands.Outputs;
using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Domain.BookingContext.Enums;
using EliteStay.Domain.BookingContext.Repositories;
using EliteStay.Domain.BookingContext.ValueObjects;
using EliteStay.Shared.Commands;
using FluentValidator;

namespace EliteStay.Domain.BookingContext.Handlers
{
  public class UserHandler : Notifiable, ICommandHandler<CreateUserCommand>
  {
    private readonly IUserRepository _repository;
    public UserHandler(IUserRepository repository)
    {
      _repository = repository;
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
        command.permission = 1;
      }

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
        command.permission == 1 ? "Normal" : "Admin");
    }
  }
}