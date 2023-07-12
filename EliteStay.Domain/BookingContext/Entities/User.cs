using EliteStay.Domain.BookingContext.Enums;
using EliteStay.Domain.BookingContext.ValueObjects;
using EliteStay.Shared.Entities;

namespace Elitestay.Domain.BookingContext.Entities
{
  public class User : Entity
  {
    public Name name { get; private set; }
    public string password { get; private set; }
    public Email email { get; private set; }
    public Document document { get; private set; }
    public String phone { get; private set; }
    public uint age { get; private set; }
    public EUserPermission permission { get; private set; }
  }
}