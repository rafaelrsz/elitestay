namespace EliteStay.Domain.BookingContext.Queries
{
  public class ListUsersQueryResult
  {
    public Guid id { get; set; }
    public string name { get; set; } = string.Empty;
    public string document { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
  }
}