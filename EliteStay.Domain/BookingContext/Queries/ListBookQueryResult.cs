using System.Text.Json.Serialization;
using EliteStay.Domain.BookingContext.Enums;

namespace EliteStay.Domain.BookingContext.Queries
{
  public class ListBookQueryResult
  {
    public Guid id { get; set; }
    public Guid userid { get; set; }
    public Guid roomid { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public decimal? totalPrice { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EBookStatus status { get; set; }
  }
}