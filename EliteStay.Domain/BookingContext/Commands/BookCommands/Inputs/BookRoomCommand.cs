using EliteStay.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace EliteStay.Domain.BookingContext.Commands.BookCommands.Inputs
{
  public class BookRoomCommand : Notifiable, ICommand
  {
    public Guid User { get; set; }
    public Guid Room { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public bool Valid()
    {
      AddNotifications(new ValidationContract()
          .HasLen(User.ToString(), 36, "User", "Identificador do usuário inválido")
          .HasLen(Room.ToString(), 36, "Book", "Identificador do quarto inválido")
          .IsLowerThan(startDate.Date, DateTime.Now.Date, "StartDate", "Data de entrada invalida")
          .IsLowerOrEqualsThan(endDate.Date, startDate.Date, "EndDate", "Data de saída invalida"));

      return base.Valid;
    }
  }
}

