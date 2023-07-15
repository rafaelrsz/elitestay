using EliteStay.Domain.BookingContext.Commands.BookCommands.Inputs;
using EliteStay.Domain.BookingContext.Commands.RoomCommands.Inputs;

namespace EliteStay.Tests.Commands
{
  [TestClass]
  public class CreateRoomCommandTests
  {
    [TestMethod]
    public void ShouldValidateWhenCommandIsValid()
    {
      var command = new CreateRoomCommand();
      command.capacity = 3;
      command.dailyPrice = 30;
      command.description = "test";
      command.location = "test";

      Assert.AreEqual(true, command.IsValid());
    }

    [TestMethod]
    public void ShouldNotValidateWhenCommandIsInvalid()
    {
      var command = new CreateRoomCommand();
      command.capacity = 0;
      command.dailyPrice = -2;
      command.description = "test";
      command.location = "test";

      Assert.AreEqual(false, command.IsValid());
    }
  }
}