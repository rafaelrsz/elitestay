using EliteStay.Domain.BookingContext.Commands.UserCommands.Inputs;
using EliteStay.Domain.BookingContext.Enums;

namespace EliteStay.Tests.Commands
{
  public class CreateUserCommandTests
  {
    [TestMethod]
    public void ShouldValidateWhenCommandIsValid()
    {
      var command = new CreateUserCommand();
      command.firstName = "FirstName";
      command.lastName = "LastName";
      command.document = "40438088018";
      command.email = "email@example.com";
      command.password = "1234";
      command.age = 18;
      command.permission = EUserPermission.Normal;
      command.phone = "32148664";

      Assert.AreEqual(true, command.IsValid());
    }

    [TestMethod]
    public void ShouldNotValidateWhenCommandIsInvalid()
    {
      var command = new CreateUserCommand();
      command.firstName = "";
      command.lastName = "LastName";
      command.document = "40438088018";
      command.email = "email@example.com";
      command.password = "1234";
      command.age = 18;
      command.permission = EUserPermission.Normal;
      command.phone = "32148664";

      Assert.AreEqual(false, command.IsValid());
    }
  }
}