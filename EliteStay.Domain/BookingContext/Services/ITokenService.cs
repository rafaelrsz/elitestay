using EliteStay.Domain.BookingContext.Entities;

namespace EliteStay.Domain.BookingContext.Services
{
  public interface ITokenService
  {
    string GenerateToken(User user);
  }
}