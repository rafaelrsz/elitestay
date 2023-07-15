using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Domain.BookingContext.Enums;
using EliteStay.Domain.BookingContext.Queries;

namespace EliteStay.Domain.BookingContext.Repositories
{
  public interface IBookRepository
  {
    bool CheckDate(DateTime startDate, DateTime endDate, Guid roomId);
    void Save(Book book);
    ListBookQueryResult Get(Guid id);
    IEnumerable<ListBookQueryResult> Get();
    void UpdateStatus(Guid id, EBookStatus status);
    IEnumerable<ListBookQueryResult> GetByUser(Guid userId);
    IEnumerable<ListBookQueryResult> GetByRoom(Guid roomId);
  }
}