using EliteStay.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace EliteStay.Domain.BookingContext.Commands.UserCommands.Inputs
{
  public class CreateRoomCommandResult : ICommandResult
  {
    public CreateRoomCommandResult(string description, string location, decimal dailyPrice, uint capacity)
    {
      this.description = description;
      this.location = location;
      this.dailyPrice = dailyPrice;
      this.capacity = capacity;
    }

    public string description { get; set; } = string.Empty;
    public string location { get; set; } = string.Empty;
    public decimal dailyPrice { get; set; }
    public uint capacity { get; set; }

  }
}

