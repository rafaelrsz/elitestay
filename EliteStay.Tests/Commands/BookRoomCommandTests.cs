using EliteStay.Domain.BookingContext.Commands.BookCommands.Inputs;
namespace EliteStay.Tests.Commands
{
  public class BookRoomCommandTests
  {
    [TestMethod]
    public void ShouldValidateWhenCommandIsValid()
    {
      var command = new CreateBookRoomCommand();
      command.RoomId = Guid.NewGuid();
      command.UserId = Guid.NewGuid();

      Assert.AreEqual(true, command.IsValid());
    }

    [TestMethod]
    public void ShouldNotValidateWhenCommandIsInvalid()
    {
      var command = new CreateBookRoomCommand();

      Assert.AreEqual(false, command.IsValid());
    }
  }
}