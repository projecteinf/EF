/***
    Afegir paquet SqlClient
        dotnet add package Microsoft.Data.SqlClient
***/

using System;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json.Linq;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using BoscComa.Connexio;
using BoscComa.GestioErrors;

namespace BoscComa.ADO
{
    public class MSSQLConnectionVault : IConnection<SqlConnection>
    {
        private static MSSQLConnectionVault? _connectionDB;
        private SqlConnection _connectionMSSQL;
        private string _connectionString;

        private MSSQLConnectionVault(string connectionString)
        {
            _connectionString = connectionString;
            _connectionMSSQL = new SqlConnection(_connectionString);
        }

        public static async Task InicialitzarAsync(string vaultToken)
        {
            if (_connectionDB == null)
            {
                string connectionString = await ObtenirConnectionStringDesDeVaultAsync(vaultToken);
                _connectionDB = new MSSQLConnectionVault(connectionString);
            }
        }

        public static MSSQLConnectionVault ConnectionDB
        {
            get
            {
                if (_connectionDB == null)
                {
                    throw new InvalidOperationException("La connexió no ha estat inicialitzada. Crida InicialitzarAsync() primer.");
                }
                return _connectionDB;
            }
        }

        private static async Task<string> ObtenirConnectionStringDesDeVaultAsync(string vaultToken)
        {
            string vaultAddress = "https://127.0.0.1:8200";
            string secretPath = "secrets/config/mssql";
            string expectedThumbprint = "04E6380CD5F962E7BC39944564E30F0292708090";

            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                if (sslPolicyErrors == SslPolicyErrors.None)
                    return true;

                string actualThumbprint = cert?.GetCertHashString()?.ToUpperInvariant();
                return actualThumbprint == expectedThumbprint;
            };

            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(vaultAddress);
                client.DefaultRequestHeaders.Add("X-Vault-Token", vaultToken);

                HttpResponseMessage response = await client.GetAsync($"/v1/{secretPath}");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    JObject data = JObject.Parse(json)["data"] as JObject;

                    string username = data["username"]?.ToString();
                    string password = data["password"]?.ToString();

                    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                    {
                        throw new Exception("Les credencials de Vault estan buides o malformades.");
                    }

                    return $"Server=localhost;Database=dbDemo;User Id={username};Password={password};TrustServerCertificate=True;";
                }
                else
                {
                    throw new Exception($"No s'han pogut obtenir les credencials de Vault: {response.StatusCode}");
                }
            }
        }

        public void Obrir()
        {
            try
            {
                if (_connectionMSSQL.State == System.Data.ConnectionState.Closed)
                {
                    _connectionMSSQL.Open();
                }
            }
            catch (SqlException sqlEx)
            {
                StringConnection connection = new StringConnection(_connectionString);
                throw new DBException(sqlEx.Message, DBOperation.Open, sqlEx.ErrorCode, connection.GetHost(), connection.GetDatabase(), connection.GetUser(), sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la connexió.", ex);
            }
        }

        public void Tancar()
        {
            if (_connectionMSSQL.State == System.Data.ConnectionState.Open)
            {
                _connectionMSSQL.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return _connectionMSSQL;
        }
    }
}
