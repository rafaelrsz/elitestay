using EliteStay.Domain.BookingContext.Entities;

namespace EliteStay.Domain.BookingContext.Repositories
{
  public interface IUserRepository
  {
    bool CheckDocument(string document);
    bool CheckEmail(string email);
    void Save(User user);
  }
}