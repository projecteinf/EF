using static System.Console;

namespace BoscComa.Connexio 
{
    class Program 
    {
        static void Main()
        {
            DadesXifratge dadesXifratge = new DadesXifratge();
            WriteLine("Key: {0}",Convert.ToBase64String(dadesXifratge.Key));
            WriteLine("Vector inicialtizació: {0}",Convert.ToBase64String(dadesXifratge.VectorInicialitzacio));
        }
    }
}
