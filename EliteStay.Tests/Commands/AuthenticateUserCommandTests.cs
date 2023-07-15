using EliteStay.Domain.BookingContext.Commands.UserCommands.Inputs;

namespace EliteStay.Tests.Commands
{
  [TestClass]
  public class AuthenticateUserCommandTests
  {
    [TestMethod]
    public void ShouldValidateWhenCommandIsValid()
    {
      var command = new AuthenticateUserCommand();
      command.email = "test@gmail.com";
      command.password = "password";

      Assert.AreEqual(true, command.IsValid());
    }

    [TestMethod]
    public void ShouldNotValidateWhenCommandIsInvalid()
    {
      var command = new AuthenticateUserCommand();
      command.email = "test";
      command.password = "";

      Assert.AreEqual(false, command.IsValid());
    }
  }
}