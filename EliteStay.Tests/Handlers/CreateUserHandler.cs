using EliteStay.Domain.BookingContext.Commands.UserCommands.Inputs;
using EliteStay.Domain.BookingContext.Enums;
using EliteStay.Domain.BookingContext.Handlers;
using EliteStay.Tests.Fakes;

namespace EliteStay.Tests.Handlers
{
  [TestClass]
  public class CreateUserHandler
  {
    [TestMethod]
    public void ShouldBeAbleToRegisterAnUser()
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

      var handler = new UserHandler(new FakeUserRepository());
      var result = handler.Handle(command);

      Assert.AreNotEqual(null, result);
      Assert.AreEqual(true, handler.Valid);
    }
  }
}