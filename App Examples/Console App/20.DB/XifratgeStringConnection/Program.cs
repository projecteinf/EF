using static System.Console;
using BoscComa.GestioErrors;

namespace BoscComa.Connexio 
{
    class Program 
    {
        static void Main()
        {
            string path=@"/home/projecteinf/Projectes/2025/EF/App Examples/Console App/20.DB/ADO/Config";
            string filename=@"connction.enc";

            StringConnection stringConnection = new StringConnection("localhost", "dbDemo", "SA", "Patata1234" );
            try
            {
                stringConnection.Store(path, filename, overwrite: true);
            }
            catch (FileException ex)
            {
                Console.WriteLine($"Error: {ex.TipusError} - {ex.Message}");
            }
            WriteLine(StringConnection.GetDecrypt(path,filename));
        }
    }
}
