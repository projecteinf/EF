/***
    Afegir paquet SqlClient
        dotnet add package Microsoft.Data.SqlClient
***/

using Microsoft.Data.SqlClient;
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
            catch (SqlException sqlEx)
            {
                throw new Exception("Error en la connexió.", sqlEx);
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
        public void Obrir()
        {
            if (this.ConnectionMSSQL.State == System.Data.ConnectionState.Closed)
            {
                this.ConnectionMSSQL.Open();
            }
        }
        public void Tancar()
        {
            if (this.ConnectionMSSQL.State == System.Data.ConnectionState.Open)
            {
                this.ConnectionMSSQL.Close();
            }
        }
    }
}