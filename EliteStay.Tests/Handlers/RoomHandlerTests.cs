using EliteStay.Domain.BookingContext.Commands.RoomCommands.Inputs;
using EliteStay.Domain.BookingContext.Handlers;
using EliteStay.Tests.Fakes;

namespace EliteStay.Tests.Handlers
{
  [TestClass]
  public class RoomHandlerTests
  {
    [TestMethod]
    public void ShouldBeAbleToRegisterARoom()
    {
      var command = new CreateRoomCommand();
      command.capacity = 3;
      command.dailyPrice = 30;
      command.description = "test";
      command.location = "test";

      Assert.AreEqual(true, command.IsValid());

      var handler = new RoomHandler(new FakeRoomRepository());
      var result = handler.Handle(command);

      Assert.AreNotEqual(null, result);
      Assert.AreEqual(true, handler.Valid);
    }
  }
}