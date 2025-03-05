using static System.Console;
using BoscComa.GestioErrors;

namespace BoscComa.Connexio 
{
    class Program 
    {
        static void Main()
        {
            // DadesXifratgeAES dadesXifratge = DadesXifratgeAES.XifratgeAES;
            // WriteLine("Key: {0}",Convert.ToBase64String(dadesXifratge.ObtenirClau()));
            // WriteLine("Vector inicialtizació: {0}",Convert.ToBase64String(dadesXifratge.ObtenirVectorInicialitzacio()));

            StringConnection stringConnection = new StringConnection("localhost", "dbDemo", "SA", "Patata1234" );
            try
            {
                stringConnection.Store(@"/home/projecteinf/", "connexio.dat", overwrite: true);
            }
            catch (FileException ex)
            {
                Console.WriteLine($"Error: {ex.TipusError} - {ex.Message}");
            }
            WriteLine(stringConnection.Decrypt(@"/home/projecteinf/", "connexio.dat"));
        }
    }
}
