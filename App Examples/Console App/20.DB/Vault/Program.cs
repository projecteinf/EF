/*
    Instal·lació paquets
        dotnet add package Newtonsoft.json 2017  
        dotnet add package Microsoft.Data.SqlClient

    Per a obtenir l'emprenta del certificat

    openssl x509 -in /home/projecteinf/Projectes/2025/EF/Docs/Docker/Vault/Produccio/certs/vault.crt -noout -fingerprint -sha1

    ThumbPrint -> sha1 Fingerprint=04:E6:38:0C:D5:F9:62:E7:BC:39:94:45:64:E3:0F:02:92:70:80:90

    Cal eliminar els ":"

    04E6380CD5F962E7BC39944564E30F0292708090

*/ 


using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
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
            
            ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                const string expectedThumbprint = "04E6380CD5F962E7BC39944564E30F0292708090";
                if (sslPolicyErrors == SslPolicyErrors.None)
                {
                    return true;
                }
                string actualThumbprint = cert?.GetCertHashString()?.ToUpperInvariant();
                return actualThumbprint == expectedThumbprint;
            }
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

