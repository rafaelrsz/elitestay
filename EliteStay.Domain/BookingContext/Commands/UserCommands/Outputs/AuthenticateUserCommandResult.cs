using EliteStay.Shared.Commands;

namespace EliteStay.Domain.BookingContext.Commands.UserCommands.Outputs
{
  public class AuthenticateUserCommandResult : ICommandResult
  {
    public AuthenticateUserCommandResult()
    {
    }

    public AuthenticateUserCommandResult(string token, string email)
    {
      this.token = token;
      this.email = email;
    }

    public string token { get; set; } = String.Empty;
    public string email { get; set; } = String.Empty;
  }
}