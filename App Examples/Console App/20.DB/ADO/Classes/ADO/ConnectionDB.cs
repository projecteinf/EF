/***
    Afegir paquet SqlClient
        dotnet add package System.Data.SqlClient
***/

using System.Data.SqlClient;
using BoscComa.Connexio;

namespace BoscComa.ADO
{
    public class Connection
    {
        public static Connection _connectionDB;
        public SqlConnection ConnectionMSSQL;
        
        private Connection(string path,string fileName) 
        {
            string connectionString = StringConnection.GetDecrypt(path,fileName);
            try 
            {
                this.ConnectionMSSQL = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la connexió.", ex);
            }
        }

        public static void Inicialitzar(string path,string fileName) 
        {
            if (Connection._connectionDB == null) 
            {
                Connection._connectionDB = new Connection(path,fileName);
            }
        }

        public static Connection ConnectionDB
        {
            get
            {
                if (Connection._connectionDB == null) 
                {
                    throw new InvalidOperationException("La connexió no ha estat inicialitzada. Crida Initialize() primer.");
                }
                return Connection._connectionDB; 
            }
        }
    }
}