namespace EliteStay.Domain.BookingContext.Utils
{
  public interface IPasswordHasher
  {
    bool Verify(string passwordHash, string inputPassword);
    string Hash(string password);
  }
}