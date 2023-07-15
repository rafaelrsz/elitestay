using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Domain.BookingContext.Services;

namespace EliteStay.Tests.Fakes
{
  public class FakeTokenService : ITokenService
  {
    public string GenerateToken(User user)
    {
      return "";
    }
  }
}