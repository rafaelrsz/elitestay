using EliteStay.Domain.BookingContext.Enums;
using EliteStay.Shared.Entities;

namespace Elitestay.Domain.BookingContext.Entities
{
  public class Room : Entity
  {
    public string description { get; private set; }
    public string location { get; private set; }
    public decimal dailyPrice { get; private set; }
    public ERoomStatus status { get; private set; }
    public uint capacity { get; private set; }

    // considerar caracteristicas do quarto, quantidade de camas, ar condicionado, etc
  }
}