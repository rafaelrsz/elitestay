using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Domain.BookingContext.Queries;

namespace EliteStay.Domain.BookingContext.Repositories
{
  public interface IRoomRepository
  {
    bool CheckLocation(string location);
    void Save(Room room);
    ListRoomQueryResult Get(Guid id);
    IEnumerable<ListRoomQueryResult> Get();
    void Delete(Guid id);
  }
}