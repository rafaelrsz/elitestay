using System.Data;
using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Domain.BookingContext.Repositories;
using EliteStay.Infra.BookingContext.DataContexts;
using Dapper;
using Dapper.Contrib.Extensions;
using EliteStay.Domain.BookingContext.Queries;

namespace EliteStay.Infra.BookingContext.Repositories
{
  public class RoomRepository : IRoomRepository
  {
    private readonly EliteStayDataContext _context;

    public RoomRepository(EliteStayDataContext context)
    {
      _context = context;
    }
    public bool CheckLocation(string location)
    {
      return
        _context
        .Connection
        .Query<bool>(
            "spCheckLocation",
            new { Location = location },
            commandType: CommandType.StoredProcedure)
        .FirstOrDefault();
    }

    public void Save(Room room)
    {
      _context.Connection.Execute("spCreateRoom",
        new
        {
          Id = room.Id,
          Description = room.description,
          Location = room.location,
          Capacity = (int)room.capacity,
          DailyPrice = room.dailyPrice
        }, commandType: CommandType.StoredProcedure);
    }
    public ListRoomQueryResult Get(Guid id)
    {
      return
        _context
        .Connection
        .Query<ListRoomQueryResult>("spGetRoom",
        new { id = id },
        commandType: CommandType.StoredProcedure)
        .FirstOrDefault() ?? new ListRoomQueryResult();
    }

    public IEnumerable<ListRoomQueryResult> Get()
    {
      return
        _context
        .Connection
        .Query<ListRoomQueryResult>("spListRooms",
        commandType: CommandType.StoredProcedure);
    }

    public void Delete(Guid id)
    {
      _context
        .Connection
        .Query("spDeleteRoom"
        , new { id = id },
        commandType: CommandType.StoredProcedure);
    }

    public bool ValidateExclusion(Guid id)
    {
      return
      _context
        .Connection
        .Query<bool>(
            "spValidateRoomExclusion",
            new { Id = id },
            commandType: CommandType.StoredProcedure)
        .FirstOrDefault();
    }
  }
}
