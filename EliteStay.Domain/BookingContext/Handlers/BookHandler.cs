using EliteStay.Domain.BookingContext.Commands.BookCommands.Inputs;
using EliteStay.Domain.BookingContext.Commands.BookCommands.Outputs;
using EliteStay.Domain.BookingContext.Commands.UserCommands.Outputs;
using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Domain.BookingContext.Enums;
using EliteStay.Domain.BookingContext.Repositories;
using EliteStay.Domain.BookingContext.ValueObjects;
using EliteStay.Shared.Commands;
using FluentValidator;

namespace EliteStay.Domain.BookingContext.Handlers
{
  public class BookHandler : Notifiable, ICommandHandler<CreateBookRoomCommand>
  {
    private readonly IBookRepository _bookRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IUserRepository _userRepository;

    public BookHandler(IBookRepository bookRepository, IRoomRepository roomRepository, IUserRepository userRepository)
    {
      _bookRepository = bookRepository;
      _roomRepository = roomRepository;
      _userRepository = userRepository;
    }

    public ICommandResult? Handle(CreateBookRoomCommand Command)
    {
      var user = _userRepository.Get(Command.UserId);
      if (user.id == Guid.Empty)
        AddNotification("UserId", "Usario não encontrado");

      var room = _roomRepository.Get(Command.RoomId);
      if (room.id == Guid.Empty)
        AddNotification("RoomId", "Quarto não encontrado");


      if (_bookRepository.CheckDate(Command.startDate, Command.endDate, Command.RoomId))
        AddNotification("DatePeriod", $"O quarto em questão não está disponível no intervalo de data especificado");

      User? userEntity = null;
      Room? roomEntity = null;
      Book? book = null;
      if (Valid)
      {
        userEntity = new User(user!.id, new Name(user.name, user.name), new Email(user.email), new Document(user.document), EUserPermission.Normal);
        roomEntity = new Room(room!.id, room.description, room.location, room.dailyPrice, room.capacity);
        book = new Book(userEntity, roomEntity, Command.startDate, Command.endDate);
      }

      if (Invalid)
        return new CommandResult(
            false,
            "Por favor, corrija os campos abaixo",
            Notifications);

      _bookRepository.Save(book!);



      return new CreateBookRoomCommandResult(user!.id, room!.id, book!.startDate, book.endDate, book.totalPrice, book.status.ToString());
    }
  }
}