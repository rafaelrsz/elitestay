using EliteStay.Shared.Commands;

namespace EliteStay.Domain.BookingContext.Commands.UserCommands.Outputs
{
  public class GetUserCommandResult : ICommandResult
  {
    public GetUserCommandResult() { }

    public GetUserCommandResult(Guid id, string name, string document, string email)
    {
      this.id = id;
      this.name = name;
      this.document = document;
      this.email = email;
    }

    public Guid id { get; set; }
    public string name { get; set; } = string.Empty;
    public string document { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
  }
}

