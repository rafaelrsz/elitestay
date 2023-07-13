using EliteStay.Domain.BookingContext.Commands.BookCommands.Inputs;
namespace EliteStay.Tests.Commands
{
  public class BookRoomCommandTests
  {
    [TestMethod]
    public void ShouldValidateWhenCommandIsValid()
    {
      var command = new BookRoomCommand();
      command.Room = Guid.NewGuid();
      command.User = Guid.NewGuid();

      Assert.AreEqual(true, command.IsValid());
    }

    [TestMethod]
    public void ShouldNotValidateWhenCommandIsInvalid()
    {
      var command = new BookRoomCommand();

      Assert.AreEqual(false, command.IsValid());
    }
  }
}