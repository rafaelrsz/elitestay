using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Domain.BookingContext.Queries;
using EliteStay.Domain.BookingContext.ValueObjects;

namespace EliteStay.Domain.BookingContext.Repositories
{
  public interface IUserRepository
  {
    bool CheckDocument(string document);
    bool CheckEmail(string email);
    void Save(User user);
    ListUsersQueryResult Get(Guid id);
    GetFullUserQueryResult Get(Email email);
    IEnumerable<ListUsersQueryResult> Get();
    void Delete(Guid id);
    bool ValidateExclusion(Guid id);
  }
}