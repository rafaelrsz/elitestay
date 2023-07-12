using EliteStay.Domain.BookingContext.Enums;
using EliteStay.Domain.BookingContext.ValueObjects;
using EliteStay.Shared.Entities;

namespace EliteStay.Domain.BookingContext.Entities
{
  public class User : Entity
  {
    public User(Name name,
    string password,
    Email email,
    Document document,
    String phone,
    uint age,
    EUserPermission permission)
    {
      this.name = name;
      this.password = password;
      this.email = email;
      this.phone = phone;
      this.age = age;
      this.document = document;
      this.permission = permission;
    }

    public Name name { get; private set; }
    public string password { get; private set; }
    public Email email { get; private set; }
    public Document document { get; private set; }
    public String phone { get; private set; }
    public uint age { get; private set; }
    public EUserPermission permission { get; private set; }

    public override string ToString()
    {
      return name.ToString();
    }
  }
}