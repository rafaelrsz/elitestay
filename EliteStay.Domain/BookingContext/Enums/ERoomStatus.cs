using System.Text.Json.Serialization;

namespace EliteStay.Domain.BookingContext.Enums
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum ERoomStatus
  {
    NotAvailable = 1
  }
}