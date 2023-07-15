using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Domain.BookingContext.Enums;
using EliteStay.Domain.BookingContext.Queries;
using EliteStay.Domain.BookingContext.Repositories;

namespace EliteStay.Tests.Fakes
{
  public class FakeBookRepository : IBookRepository
  {
    public bool CheckDate(DateTime startDate, DateTime endDate, Guid roomId)
    {
      return false;
    }

    public ListBookQueryResult Get(Guid id)
    {
      return new ListBookQueryResult();
    }

    public IEnumerable<ListBookQueryResult> Get()
    {
      return new List<ListBookQueryResult>();
    }

    public IEnumerable<ListBookQueryResult> GetByRoom(Guid roomId)
    {
      return new List<ListBookQueryResult>();
    }

    public IEnumerable<ListBookQueryResult> GetByUser(Guid userId)
    {
      return new List<ListBookQueryResult>();
    }

    public void Save(Book book)
    {

    }

    public void UpdateStatus(Guid id, EBookStatus status)
    {

    }
  }
}