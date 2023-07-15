using EliteStay.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace EliteStay.Domain.BookingContext.Commands.RoomCommands.Inputs
{
  public class CreateRoomCommand : Notifiable, ICommand
  {
    public string description { get; set; } = string.Empty;
    public string location { get; set; } = string.Empty;
    public decimal dailyPrice { get; set; }
    public uint capacity { get; set; }

    public bool IsValid()
    {
      AddNotifications(new ValidationContract()
          .IsGreaterThan((int)capacity, 0, "Capacity", "Capacidade do quarto deve ser maior que zero")
          .IsGreaterThan((int)dailyPrice, 0, "DailyPrice", "Diaria deve ser maior que zero")
      );
      return base.Valid;
    }
  }
}

