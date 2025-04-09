using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Microsoft.Data.SqlClient;

class Program
{
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        string vaultToken = "hvs.qj8dN3I23ylUkPJHncl4Wpu6"; // El teu token root
        string vaultAddress = "https://127.0.0.1:8200";     // L'adreça del teu Vault
        string secretPath = "secrets/config/mssql";       // Ruta on Vault exposa les credencials

        HttpClientHandler handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
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

                string username = data["username"].ToString();
                string password = data["password"].ToString();

                Console.WriteLine($"Usuari: {username}");
                Console.WriteLine($"Password: {password}");

                // Connexió a la base de dades
                string connectionString = $"Server=localhost;Database=dbDemo;User Id={username};Password={password};TrustServerCertificate=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connexió amb èxit!");
                }
            }
            else
            {
                Console.WriteLine($"Error accedint a Vault: {response.StatusCode}");
            }
        }
    }
}

