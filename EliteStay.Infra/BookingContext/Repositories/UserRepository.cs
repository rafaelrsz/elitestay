using System.Data;
using EliteStay.Domain.BookingContext.Entities;
using EliteStay.Domain.BookingContext.Repositories;
using EliteStay.Infra.BookingContext.DataContexts;
using Dapper;
using Dapper.Contrib.Extensions;
using EliteStay.Domain.BookingContext.Queries;
using EliteStay.Domain.BookingContext.ValueObjects;

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

    public ListUsersQueryResult Get(Guid id)
    {
      return
        _context
        .Connection
        .Query<ListUsersQueryResult>("spGetUser",
        new { id = id },
        commandType: CommandType.StoredProcedure)
        .FirstOrDefault() ?? new ListUsersQueryResult();
    }

    public IEnumerable<ListUsersQueryResult> Get()
    {
      return
        _context
        .Connection
        .Query<ListUsersQueryResult>("spListUsers",
        commandType: CommandType.StoredProcedure);
    }

    public void Delete(Guid id)
    {
      _context
      .Connection
      .Query("spDeleteUser"
      , new { id = id },
      commandType: CommandType.StoredProcedure);
    }

    public bool CheckAuth(string email, string passwordHash)
    {
      return _context
        .Connection
        .Query<bool>(
            "spCheckAuth",
            new { Email = email, PasswordHash = passwordHash },
            commandType: CommandType.StoredProcedure)
        .FirstOrDefault();
    }

    public GetFullUserQueryResult Get(Email email)
    {
      return
      _context
        .Connection
        .Query<GetFullUserQueryResult>("spGetUserByEmail",
        new { Email = email.Address },
        commandType: CommandType.StoredProcedure)
        .FirstOrDefault() ?? new GetFullUserQueryResult();
    }

    public bool ValidateExclusion(Guid id)
    {
      return
      _context
        .Connection
        .Query<bool>(
            "spValidateUserExclusion",
            new { Id = id },
            commandType: CommandType.StoredProcedure)
        .FirstOrDefault();
    }
  }
}
