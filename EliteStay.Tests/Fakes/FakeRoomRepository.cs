using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Domain.BookingContext.Queries;
using EliteStay.Domain.BookingContext.Repositories;

namespace EliteStay.Tests.Fakes
{
  public class FakeRoomRepository : IRoomRepository
  {
    public bool CheckLocation(string location)
    {
      return false;
    }

    public void Delete(Guid id)
    {

    }

    public ListRoomQueryResult Get(Guid id)
    {
      return new ListRoomQueryResult() { id = Guid.NewGuid() };
    }

    public IEnumerable<ListRoomQueryResult> Get()
    {
      return new List<ListRoomQueryResult>() { new ListRoomQueryResult() };
    }

    public void Save(Room room)
    {
    }

    public bool ValidateExclusion(Guid id)
    {
      return false;
    }
  }
}