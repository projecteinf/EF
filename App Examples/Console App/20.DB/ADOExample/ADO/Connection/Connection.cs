/***
    Afegir paquet SqlClient
        dotnet add package Microsoft.Data.SqlClient
***/

using Microsoft.Data.SqlClient;
using BoscComa.Connexio;
using BoscComa.GestioErrors;

namespace BoscComa.ADO
{
    public class Connection : IConnection
    {
        public static Connection? _connectionDB;
        public SqlConnection ConnectionMSSQL;        
        private string connectionString;    // Necessitem la cadena de connexió per a poder obtenir els paràmetres host,database,user. Cal pensar una millor opció!!
        private Connection(string path,string fileName) 
        {
            this.connectionString = StringConnection.GetDecrypt(path,fileName);
            this.ConnectionMSSQL = new SqlConnection(connectionString);
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
            try 
            {
                if (this.ConnectionMSSQL.State == System.Data.ConnectionState.Closed)
                {
                    this.ConnectionMSSQL.Open();
                }
            }
            catch (SqlException sqlEx)
            {
                StringConnection connection = new StringConnection(this.connectionString);
                throw new DBException(sqlEx.Message, DBOperation.Open, sqlEx.ErrorCode, connection.GetHost(), connection.GetDatabase(), connection.GetUser(), sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la connexió.", ex);
            }
        }
        public void Tancar()
        {
            if (this.ConnectionMSSQL.State == System.Data.ConnectionState.Open)
            {
                this.ConnectionMSSQL.Close();
            }
        }
        public SqlConnection GetConnection()
        {
            return this.ConnectionMSSQL;
        }
    }
}