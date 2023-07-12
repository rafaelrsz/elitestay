using EliteStay.Domain.BookingContext.Enums;
using EliteStay.Shared.Entities;

namespace Elitestay.Domain.BookingContext.Entities
{
  public class Room : Entity
  {
    public Room(string description, string location, decimal dailyPrice, uint capacity)
    {
      this.description = description;
      this.location = location;
      this.dailyPrice = dailyPrice;
      this.capacity = capacity;

      this.status = new Dictionary<DateTime, ERoomStatus>();
    }
    public string description { get; private set; }
    public string location { get; private set; }
    public decimal dailyPrice { get; private set; }
    public Dictionary<DateTime, ERoomStatus> status { get; private set; }
    public uint capacity { get; private set; }

    // considerar caracteristicas do quarto, quantidade de camas, ar condicionado, etc
    public void Book(DateTime startDate, DateTime endDate)
    {
      for (DateTime date = startDate; date <= endDate; date.AddDays(1))
      {
        status.Add(date, ERoomStatus.NotAvailable);
      }
    }

    public void Release(DateTime dateTime)
    {
      status.Remove(dateTime);
    }

    public bool IsAvailable(DateTime startDate, DateTime endDate)
    {
      for (DateTime date = startDate; date <= endDate; date.AddDays(1))
      {
        if (status.ContainsKey(date))
          return false;
      }

      return true;
    }

    public void CancelBook(DateTime startDate, DateTime endDate)
    {
      for (DateTime date = startDate; date <= endDate; date.AddDays(1))
      {
        status.Remove(date);
      }
    }
  }
}