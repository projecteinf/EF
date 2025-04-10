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
using System.Threading.Tasks;
using BoscComa.ADO;

class Program
{
    static async Task Main(string[] args)
    {
        MSSQLConnectionVault connection = await ConnectToDB();
        connection.Obrir();

        Console.WriteLine("Connexió establerta!");
    }

    private static async Task<MSSQLConnectionVault> ConnectToDB()
    {
        string vaultToken = "hvs.qj8dN3I23ylUkPJHncl4Wpu6"; // Token root

        await MSSQLConnectionVault.InicialitzarAsync(vaultToken);
        return MSSQLConnectionVault.ConnectionDB;
    }
}

