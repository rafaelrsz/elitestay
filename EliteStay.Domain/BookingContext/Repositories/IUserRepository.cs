using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Domain.BookingContext.Queries;

namespace EliteStay.Domain.BookingContext.Repositories
{
  public interface IUserRepository
  {
    bool CheckDocument(string document);
    bool CheckEmail(string email);
    void Save(User user);
    ListUsersQueryResult Get(Guid id);
    IEnumerable<ListUsersQueryResult> Get();
    void Delete(Guid id);
  }
}