using EliteStay.Domain.BookingContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EliteStay.Tests.ValueObjects
{
  [TestClass]
  public class DocumentTests
  {
    private Document validDocument;
    private Document invalidDocument;

    public DocumentTests()
    {
      validDocument = new Document("40438088018");
      invalidDocument = new Document("04746283942");
    }

    [TestMethod]
    public void ShouldReturnNotificationWhenDocumentIsNotValid()
    {
      Assert.AreEqual(false, invalidDocument.Valid);
      Assert.AreEqual(1, invalidDocument.Notifications.Count);
    }

    [TestMethod]
    public void ShouldNotReturnNotificationWhenDocumentIsValid()
    {
      Assert.AreEqual(true, validDocument.Valid);
      Assert.AreEqual(0, validDocument.Notifications.Count);
    }

    [TestMethod]
    public void ShouldReturnNotificationWhenAllDigitsAreSame()
    {
      var document = new Document("11111111111");
      Assert.AreEqual(false, document.Valid);
      Assert.AreEqual(1, document.Notifications.Count);
    }
  }
}