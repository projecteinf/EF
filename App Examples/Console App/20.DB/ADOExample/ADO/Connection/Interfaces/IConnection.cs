using Microsoft.Data.SqlClient;

// Utilitzem genèrics per què hem de retornar SqlConnection per MSSQL i ConnectionMultiplexer per Redis

namespace BoscComa.ADO
{
    public interface IConnection<T> 
    {
        T GetConnection();
        void Obrir();
        void Tancar();
    }
}
