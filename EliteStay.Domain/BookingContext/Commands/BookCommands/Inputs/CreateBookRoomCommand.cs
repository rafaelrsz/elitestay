using EliteStay.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace EliteStay.Domain.BookingContext.Commands.BookCommands.Inputs
{
  public class CreateBookRoomCommand : Notifiable, ICommand
  {
    public Guid UserId { get; set; }
    public Guid RoomId { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public bool IsValid()
    {
      AddNotifications(new ValidationContract()
          .HasLen(UserId.ToString(), 36, "User", "Identificador do usuário inválido")
          .HasLen(RoomId.ToString(), 36, "Book", "Identificador do quarto inválido")
          .IsLowerThan(startDate.Date, DateTime.Now.Date, "StartDate", "Data de entrada invalida")
          .IsLowerOrEqualsThan(endDate.Date, startDate.Date, "EndDate", "Data de saída invalida"));

      return base.Valid;
    }
  }
}

