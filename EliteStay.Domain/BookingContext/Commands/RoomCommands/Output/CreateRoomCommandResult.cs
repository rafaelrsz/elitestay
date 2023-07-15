using EliteStay.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace EliteStay.Domain.BookingContext.Commands.UserCommands.Outputs
{
  public class CreateRoomCommandResult : ICommandResult
  {
    public CreateRoomCommandResult(Guid id, string description, string location, decimal dailyPrice, uint capacity)
    {
      this.id = id;
      this.description = description;
      this.location = location;
      this.dailyPrice = dailyPrice;
      this.capacity = capacity;
    }

    public Guid id { get; set; }
    public string description { get; set; } = string.Empty;
    public string location { get; set; } = string.Empty;
    public decimal dailyPrice { get; set; }
    public uint capacity { get; set; }

  }
}

