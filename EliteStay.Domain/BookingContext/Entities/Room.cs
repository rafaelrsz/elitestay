using EliteStay.Domain.BookingContext.Enums;
using EliteStay.Shared.Entities;

namespace EliteStay.Domain.BookingContext.Entities
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
      for (DateTime date = startDate; date.Date <= endDate.Date; date = date.AddDays(1))
      {
        if (!status.ContainsKey(date.Date))
          status.Add(date.Date, ERoomStatus.NotAvailable);
      }
    }

    public bool IsAvailable(DateTime startDate, DateTime endDate)
    {
      if (status.Count == 0)
        return true;

      for (DateTime date = startDate; date.Date <= endDate.Date; date = date.AddDays(1))
      {
        if (status.ContainsKey(date.Date))
          return false;
      }

      return true;
    }

    public void CancelBook(DateTime startDate, DateTime endDate)
    {
      for (DateTime date = startDate; date.Date <= endDate.Date; date = date.AddDays(1))
      {
        if (status.ContainsKey(date.Date))
          status.Remove(date.Date);
      }
    }
  }
}