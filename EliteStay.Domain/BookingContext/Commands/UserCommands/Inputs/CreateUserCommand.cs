using EliteStay.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace EliteStay.Domain.BookingContext.Commands.UserCommands.Inputs
{
  public class CreateUserCommand : Notifiable, ICommand
  {
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public string document { get; set; }
    public string phone { get; set; }
    public uint age { get; set; }
    public int permission { get; set; }

    public bool Valid()
    {
      AddNotifications(new ValidationContract()
          .HasMinLen(firstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
          .HasMaxLen(firstName, 40, "FirstName", "O nome deve conter no máximo 40 caracteres")
          .HasMinLen(lastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres")
          .HasMaxLen(lastName, 40, "LastName", "O sobrenome deve conter no máximo 40 caracteres")
          .IsEmail(email, "Email", "O E-mail é inválido")
          .HasLen(document, 11, "Document", "CPF inválido")
      );
      return base.Valid;
    }
  }
}

