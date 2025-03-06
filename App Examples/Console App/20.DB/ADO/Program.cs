using System;
using System.Collections;
using static System.Console;
using BoscComa.ADO;

namespace BoscComa.AppERP
{
    public class Program 
    {
        public static void Main() 
        {
            string path=@"/home/projecteinf/Projectes/2025/EF/App Examples/Console App/20.DB/ADO/Config";
            string fileName=@"connction.enc";
            Connection.Inicialitzar(path, fileName);
            Connection connection = Connection.ConnectionDB;
            connection.Obrir(); // Bona pràctica tenir oberta la connexió quan és necessari!!
            VeurePropietats(connection);
            connection.Tancar();
            VeurePropietats(connection);
        }
        public static void VeurePropietats(Connection con)
        {
            WriteLine("Estat de la connexió: " + con.ConnectionMSSQL.State);
            if (con.ConnectionMSSQL.State  == System.Data.ConnectionState.Open)
            {
                WriteLine("Base de dades: " + con.ConnectionMSSQL.Database);
                WriteLine("Versió del servidor: " + con.ConnectionMSSQL.ServerVersion);
            }
            WriteLine("Cadena de connexió: " + con.ConnectionMSSQL.ConnectionString);
            
            WriteLine("Nom del servidor: " + con.ConnectionMSSQL.DataSource);
            WriteLine("Timeout de connexió: " + con.ConnectionMSSQL.ConnectionTimeout);

        }
    }
}