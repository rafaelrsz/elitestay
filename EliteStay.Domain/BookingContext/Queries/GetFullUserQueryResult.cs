using EliteStay.Domain.BookingContext.Enums;

namespace EliteStay.Domain.BookingContext.Queries
{
  public class GetFullUserQueryResult
  {
    public Guid id { get; set; }
    public string name { get; set; } = string.Empty;
    public string document { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public EUserPermission permission { get; set; }
    public string password { get; set; } = string.Empty;
  }
}