using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Domain.BookingContext.ValueObjects;
using EliteStay.Domain.BookingContext.Enums;

namespace EliteStay.Tests.Entities
{
  [TestClass]
  public class BookTests
  {
    private Room room;
    private User user;
    public BookTests()
    {
      room = new Room("Example Room", "Ap404", 50, 2);
      var name = new Name("FirstName", "LastName");
      var email = new Email("example@email.com");
      var document = new Document("40438088018");
      user = new User(name, "", email, document, "37999584571", 18, EUserPermission.Normal);
    }

    [TestMethod]
    public void ShouldBeAbleBookARoom()
    {
      var book = new Book(user, room, DateTime.Now, DateTime.Now.AddDays(1));
      Assert.AreEqual(true, book.Valid);
      Assert.AreEqual(0, book.Notifications.Count);
    }

    [TestMethod]
    public void ShouldNotBeAbleBookARoomWithStartDateBiggerThanEndDate()
    {
      var book = new Book(user, room, DateTime.Now, DateTime.Now.AddDays(-1));
      Assert.AreEqual(false, book.Valid);
      Assert.AreEqual(1, book.Notifications.Count);
    }

    [TestMethod]
    public void ShouldNotBeAbleToBookANotAvailableRoom()
    {
      var book1 = new Book(user, room, DateTime.Now, DateTime.Now.AddDays(1));
      var book2 = new Book(user, room, DateTime.Now, DateTime.Now.AddDays(1));

      Assert.AreEqual(false, book2.Valid);
      Assert.AreEqual(1, book2.Notifications.Count);
    }

    [TestMethod]
    public void ShouldNotBeAbleBookARoomWithStartDateSmallerThanDateNow()
    {
      var book = new Book(user, room, DateTime.Now.AddDays(-1), DateTime.Now);
      Assert.AreEqual(false, book.Valid);
      Assert.AreEqual(1, book.Notifications.Count);
    }
  }
}