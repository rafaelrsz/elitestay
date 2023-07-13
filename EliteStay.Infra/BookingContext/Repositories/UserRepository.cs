using System.Data;
using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Domain.BookingContext.Repositories;
using EliteStay.Infra.DataContexts;
using Dapper;
using Dapper.Contrib.Extensions;

namespace EliteStay.Infra.BookingContext.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly EliteStayDataContext _context;

    public UserRepository(EliteStayDataContext context)
    {
      _context = context;
    }

    public bool CheckDocument(string document)
    {
      return
          _context
          .Connection
          .Query<bool>(
              "spCheckDocument",
              new { Document = document },
              commandType: CommandType.StoredProcedure)
          .FirstOrDefault();
    }

    public bool CheckEmail(string email)
    {
      return _context
          .Connection
          .Query<bool>(
              "spCheckEmail",
              new { Email = email },
              commandType: CommandType.StoredProcedure)
          .FirstOrDefault();
    }

    public void Save(User user)
    {
      _context.Connection.Execute("spCreateUser",
            new
            {
              Id = user.Id,
              FirstName = user.name.FirstName,
              LastName = user.name.LastName,
              Password = user.password,
              Document = user.document.Number,
              Email = user.email.Address,
              Phone = user.phone,
              Age = (int)user.age,
              Permission = user.permission
            }, commandType: CommandType.StoredProcedure);
    }
  }
}