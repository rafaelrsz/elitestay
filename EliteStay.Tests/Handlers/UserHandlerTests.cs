using EliteStay.Domain.BookingContext.Commands.UserCommands.Inputs;
using EliteStay.Domain.BookingContext.Enums;
using EliteStay.Domain.BookingContext.Handlers;
using EliteStay.Tests.Fakes;

namespace EliteStay.Tests.Handlers
{
  [TestClass]
  public class UserHandlerTests
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

      var handler = new UserHandler(new FakeUserRepository(), new FakePasswordHasher(), new FakeTokenService());
      var result = handler.Handle(command);

      Assert.AreNotEqual(null, result);
      Assert.AreEqual(true, handler.Valid);
    }

    [TestMethod]
    public void ShouldBeAbleToAuthenticateAnUser()
    {
      var command = new AuthenticateUserCommand();
      command.email = "a@gmail.com";
      command.password = "password";

      Assert.AreEqual(true, command.IsValid());

      var handler = new UserHandler(new FakeUserRepository(), new FakePasswordHasher(), new FakeTokenService());

      Assert.AreEqual(true, handler.Valid);
    }
  }
}