using EliteStay.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace EliteStay.Domain.BookingContext.Commands.BookCommands.Outputs
{
  public class CreateBookRoomCommandResult : ICommandResult
  {
    public CreateBookRoomCommandResult(Guid user, Guid room, DateTime startDate, DateTime endDate, decimal totalPrice, string status)
    {
      this.user = user;
      this.room = room;
      this.startDate = startDate;
      this.endDate = endDate;
      this.totalPrice = totalPrice;
      this.status = status;
    }

    public Guid user { get; set; }
    public Guid room { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public decimal totalPrice { get; set; }
    public string status { get; set; }
  }
}

