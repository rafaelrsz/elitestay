using EliteStay.Domain.BookingContext.Commands.UserCommands.Inputs;
using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Domain.BookingContext.Repositories;

namespace EliteStay.Tests.Fakes
{
  public class FakeUserRepository : IUserRepository
  {
    public bool CheckDocument(string document)
    {
      return false;
    }

    public bool CheckEmail(string email)
    {
      return false;
    }

    public void Save(User user)
    {

    }
  }
}