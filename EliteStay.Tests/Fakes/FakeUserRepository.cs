using EliteStay.Domain.BookingContext.Commands.UserCommands.Inputs;
using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Domain.BookingContext.Enums;
using EliteStay.Domain.BookingContext.Queries;
using EliteStay.Domain.BookingContext.Repositories;
using EliteStay.Domain.BookingContext.ValueObjects;

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

    public void Delete(Guid id)
    {

    }

    public ListUsersQueryResult Get(Guid id)
    {
      return new ListUsersQueryResult() { id = Guid.NewGuid() };
    }

    public IEnumerable<ListUsersQueryResult> Get()
    {
      return new List<ListUsersQueryResult>() { new ListUsersQueryResult() };
    }

    public GetFullUserQueryResult Get(Email email)
    {
      return new GetFullUserQueryResult() { password = "password" };
    }

    public void Save(User user)
    {

    }

    public bool ValidateExclusion(Guid id)
    {
      return false;
    }
  }
}