using EliteStay.Domain.BookingContext.Enums;
using EliteStay.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace EliteStay.Domain.BookingContext.Commands.UserCommands.Inputs
{
  public class AuthenticateUserCommand : Notifiable
  {
    public string email { get; set; } = "";
    public string password { get; set; } = "";

    public bool IsValid()
    {
      AddNotifications(new ValidationContract()
        .IsEmail(email.ToString(), "Email", "Email do usuário inválido")
        .HasMinLen(password.ToString(), 1, "Book", "Campo senha não pode estar vazio"));

      return base.Valid;
    }
  }
}

