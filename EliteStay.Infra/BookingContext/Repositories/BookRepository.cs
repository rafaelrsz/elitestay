using System.Data;
using Dapper;
using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Domain.BookingContext.Enums;
using EliteStay.Domain.BookingContext.Queries;
using EliteStay.Domain.BookingContext.Repositories;
using EliteStay.Infra.BookingContext.DataContexts;

namespace EliteStay.Infra.BookingContext.Repositories
{
  public class BookRepository : IBookRepository
  {
    private readonly EliteStayDataContext _context;

    public BookRepository(EliteStayDataContext context)
    {
      _context = context;
    }
    public bool CheckDate(DateTime startDate, DateTime endDate, Guid roomId)
    {
      return
        _context
        .Connection
        .Query<bool>(
            "spCheckDate",
            new { StartDate = startDate, EndDate = endDate, RoomId = roomId },
            commandType: CommandType.StoredProcedure)
        .FirstOrDefault();
    }

    public ListBookQueryResult Get(Guid id)
    {
      return
        _context
        .Connection
        .Query<ListBookQueryResult>("spGetBook",
        new { id = id },
        commandType: CommandType.StoredProcedure)
        .FirstOrDefault() ?? new ListBookQueryResult();
    }

    public IEnumerable<ListBookQueryResult> Get()
    {
      return
        _context
          .Connection
          .Query<ListBookQueryResult>("spListBooks",
          commandType: CommandType.StoredProcedure);
    }

    public IEnumerable<ListBookQueryResult> GetByRoom(Guid roomId)
    {
      return
      _context
        .Connection
        .Query<ListBookQueryResult>("spListBooksByRoom",
        new { RoomId = roomId },
        commandType: CommandType.StoredProcedure);
    }

    public IEnumerable<ListBookQueryResult> GetByUser(Guid userId)
    {
      return
        _context
          .Connection
          .Query<ListBookQueryResult>("spListBooksByUser",
          new { UserId = userId },
          commandType: CommandType.StoredProcedure);
    }

    public void Save(Book book)
    {
      _context.Connection.Execute("spCreateBook",
        new
        {
          Id = book.Id,
          RoomId = book.room.Id,
          UserId = book.user.Id,
          StartDate = book.startDate,
          EndDate = book.endDate,
          Status = (int)book.status,
          TotalPrice = book.totalPrice
        }, commandType: CommandType.StoredProcedure);
    }
    public void UpdateStatus(Guid id, EBookStatus status)
    {
      _context.Connection.Execute("spUpdateBookStatus",
        new
        {
          Id = id,
          Status = (int)status
        }, commandType: CommandType.StoredProcedure);
    }
  }
}