namespace EliteStay.Domain.BookingContext.Queries
{
  public class ListUsersQueryResult
  {
    public Guid id { get; set; }
    public string name { get; set; }
    public string document { get; set; }
    public string email { get; set; }
  }
}