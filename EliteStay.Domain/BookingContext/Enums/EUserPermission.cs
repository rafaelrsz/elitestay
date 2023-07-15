using System.Text.Json.Serialization;

namespace EliteStay.Domain.BookingContext.Enums
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum EUserPermission
  {
    Normal = 1,
    Admin = 2
  }
}