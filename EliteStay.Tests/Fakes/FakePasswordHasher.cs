using EliteStay.Domain.BookingContext.Utils;

namespace EliteStay.Tests.Fakes
{
  public class FakePasswordHasher : IPasswordHasher
  {
    public string Hash(string password)
    {
      return "fakepassword";
    }

    public bool Verify(string passwordHash, string inputPassword)
    {
      return passwordHash.Equals(inputPassword);
    }
  }
}