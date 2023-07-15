using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Domain.BookingContext.Enums;
using EliteStay.Domain.BookingContext.ValueObjects;

namespace EliteStay.Tests.Entities
{
  [TestClass]
  public class UserTests
  {
    [TestMethod]
    public void ShouldBeAbleToCreateAnUser()
    {
      var name = new Name("FirstName", "LastName");
      var email = new Email("example@email.com");
      var document = new Document("40438088018");
      var user = new User(name, "", email, document, "37999584571", 18, EUserPermission.Normal);

      Assert.AreEqual(true, user.Valid);
      Assert.AreEqual(0, user.Notifications.Count);
    }

    [TestMethod]
    public void ShouldNotBeAbleToCreateAnUserWithInsuficientAge()
    {
      var name = new Name("FirstName", "LastName");
      var email = new Email("example@email.com");
      var document = new Document("40438088018");
      var user = new User(name, "", email, document, "37999584571", 15, EUserPermission.Normal);

      Assert.AreEqual(false, user.Valid);
      Assert.AreEqual(1, user.Notifications.Count);
    }
  }
}