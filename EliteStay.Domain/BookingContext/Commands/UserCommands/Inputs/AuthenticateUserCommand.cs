using EliteStay.Domain.BookingContext.Enums;
using EliteStay.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace EliteStay.Domain.BookingContext.Commands.UserCommands.Inputs
{
  public class AuthenticateUserCommand
  {
    public string email { get; set; } = "";
    public string password { get; set; } = "";
  }
}

