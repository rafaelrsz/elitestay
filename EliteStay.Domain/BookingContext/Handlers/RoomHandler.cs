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
  public class RoomHandler : Notifiable, ICommandHandler<CreateRoomCommand>
  {
    private readonly IRoomRepository _repository;
    public RoomHandler(IRoomRepository repository)
    {
      _repository = repository;
    }
    public ICommandResult? Handle(CreateRoomCommand command)
    {
      if (_repository.CheckLocation(command.location))
      {
        AddNotification("Location", "Já existe um quarto com essa localização");
      }

      var room =
        new Room(command.description,
        command.location, command.dailyPrice, command.capacity);

      AddNotifications(room.Notifications);

      if (Invalid)
        return new CommandResult(
            false,
            "Por favor, corrija os campos abaixo",
            Notifications);

      _repository.Save(room);

      return new CreateRoomCommandResult(command.description,
        command.location, command.dailyPrice, command.capacity);
    }
  }
}