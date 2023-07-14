using EliteStay.Shared.Commands;

namespace EliteStay.Domain.BookingContext.Commands.UserCommands.Outputs
{
  public class CreateUserCommandResult : ICommandResult
  {
    public CreateUserCommandResult() { }
    public CreateUserCommandResult(Guid id, string firstName, string lastName, string email, string document, string phone, uint age, string permission)
    {
      this.id = id;
      this.firstName = firstName;
      this.lastName = lastName;
      this.email = email;
      this.document = document;
      this.phone = phone;
      this.age = age;
      this.permission = permission;
    }

    public Guid id { get; set; }
    public string firstName { get; set; } = "";
    public string lastName { get; set; } = "";
    public string email { get; set; } = "";
    public string document { get; set; } = "";
    public string phone { get; set; } = "";
    public uint age { get; set; }
    public string permission { get; set; } = "";
  }
}

