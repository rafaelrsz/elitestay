using EliteStay.Domain.BookingContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EliteStay.Tests.ValueObjects
{
  [TestClass]
  public class NameTests
  {
    [TestMethod]
    public void ShouldReturnNotificationWhenNameIsNotValid()
    {
      var name1 = new Name("", "LastName");
      var name2 = new Name("FirstName", "");


      Assert.AreEqual(false, name1.Valid);
      Assert.AreEqual(1, name1.Notifications.Count);
      Assert.AreEqual(false, name2.Valid);
      Assert.AreEqual(1, name2.Notifications.Count);
    }

    [TestMethod]
    public void ShouldNotReturnNotificationWhenNameIsValid()
    {
      var name = new Name("FirstName", "LastName");
      Assert.AreEqual(true, name.Valid);
      Assert.AreEqual(0, name.Notifications.Count);
    }
  }
}