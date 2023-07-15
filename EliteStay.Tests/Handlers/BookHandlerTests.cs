using EliteStay.Domain.BookingContext.Commands.BookCommands.Inputs;
using EliteStay.Domain.BookingContext.Commands.RoomCommands.Inputs;
using EliteStay.Domain.BookingContext.Handlers;
using EliteStay.Tests.Fakes;

namespace EliteStay.Tests.Handlers
{
  [TestClass]
  public class BookHandlerTests
  {
    [TestMethod]
    public void ShouldBeAbleToRegisterABook()
    {
      var command = new CreateBookRoomCommand();
      command.RoomId = Guid.NewGuid();
      command.UserId = Guid.NewGuid();

      Assert.AreEqual(true, command.IsValid());

      var handler = new BookHandler(new FakeBookRepository(), new FakeRoomRepository(), new FakeUserRepository());
      var result = handler.Handle(command);

      Assert.AreNotEqual(null, result);
      Assert.AreEqual(true, handler.Valid);
    }
  }
}