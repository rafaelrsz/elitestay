using EliteStay.Domain.BookingContext.Entities;

namespace EliteStay.Tests.Entities
{
  [TestClass]
  public class RoomTests
  {
    [TestMethod]
    public void ShouldBeAbleToCreateARoom()
    {
      var room = new Room("Example Room", "Ap404", 50, 2);
      Assert.AreEqual(true, room.Valid);
      Assert.AreEqual(0, room.Notifications.Count);
    }
  }
}