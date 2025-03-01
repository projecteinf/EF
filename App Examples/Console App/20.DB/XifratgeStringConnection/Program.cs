using static System.Console;

namespace BoscComa.Connexio 
{
    class Program 
    {
        static void Main()
        {
            DadesXifratgeAES dadesXifratge = new DadesXifratgeAES();
            WriteLine("Key: {0}",Convert.ToBase64String(dadesXifratge.Key));
            WriteLine("Vector inicialtizació: {0}",Convert.ToBase64String(dadesXifratge.VectorInicialitzacio));
        }
    }
}
