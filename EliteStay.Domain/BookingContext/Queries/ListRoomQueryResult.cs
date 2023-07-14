namespace EliteStay.Domain.BookingContext.Queries
{
  public class ListRoomQueryResult
  {
    public Guid id { get; set; }
    public string description { get; set; } = string.Empty;
    public string location { get; set; } = string.Empty;
    public decimal dailyPrice { get; set; }
    public uint capacity { get; set; }
  }
}