using Microsoft.Data.SqlClient;

namespace BoscComa.ADO
{
    public interface IConnection
    {
        SqlConnection GetConnection();
    }
}
