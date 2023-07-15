using System.Text.Json.Serialization;

namespace EliteStay.Domain.BookingContext.Enums
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum EBookStatus
  {
    Booked = 1,
    Canceled = 2,
    Payed = 3,
    Finished = 4
  }
}