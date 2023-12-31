using System.Data;
using System.Data.SqlClient;
using EliteStay.Shared;

namespace EliteStay.Infra.BookingContext.DataContexts
{
  public class EliteStayDataContext : IDisposable
  {
    public SqlConnection Connection { get; set; }

    public EliteStayDataContext()
    {
      Connection = new SqlConnection(Settings.ConnectionString);
      Connection.Open();
    }

    public void Dispose()
    {
      if (Connection.State != ConnectionState.Closed)
        Connection.Close();
    }
  }
}