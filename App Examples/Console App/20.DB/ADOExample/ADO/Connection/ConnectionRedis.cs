/***
    Afegir paquet SqlClient
        dotnet add package Microsoft.Data.SqlClient
***/

using Microsoft.Data.SqlClient;
using BoscComa.Connexio;
using BoscComa.GestioErrors;
using NRedisStack;
using NRedisStack.RedisStackCommands;
using StackExchange.Redis;

namespace BoscComa.ADO
{
    public class ConnectionRedis : IConnection<ConnectionMultiplexer>
    {
        public static ConnectionRedis? _connectionDB;
        public ConnectionMultiplexer ConnectionRedisDB;        
        private ConnectionRedis(string connectionString) 
        {
            ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
            this.ConnectionRedisDB = connectionMultiplexer;
            // IDatabase db = connectionMultiplexer.GetDatabase();
        }
        public static void Inicialitzar(string connectionString) 
        {
            if (ADO.ConnectionRedis._connectionDB == null) 
            {
                ADO.ConnectionRedis._connectionDB = new ConnectionRedis(connectionString);
            }
        }

        public static ConnectionRedis ConnectionDB
        {
            get
            {
                if (ADO.ConnectionRedis._connectionDB == null) 
                {
                    throw new InvalidOperationException("La connexió no ha estat inicialitzada. Crida Initialize() primer.");
                }
                return ADO.ConnectionRedis._connectionDB; 
            }
        }
        public void Obrir()
        {
            
        }
        public void Tancar()
        {
            
        }
        public ConnectionMultiplexer GetConnection()
        {
            return this.ConnectionRedisDB;
        }
    }
}