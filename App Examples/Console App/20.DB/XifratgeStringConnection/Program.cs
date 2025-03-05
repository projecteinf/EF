using static System.Console;
using BoscComa.Xifratge;

namespace BoscComa.Connexio 
{
    class Program 
    {
        static void Main()
        {
            DadesXifratgeAES dadesXifratge = DadesXifratgeAES.XifratgeAES;
            WriteLine("Key: {0}",Convert.ToBase64String(dadesXifratge.ObtenirClau()));
            WriteLine("Vector inicialtizació: {0}",Convert.ToBase64String(dadesXifratge.ObtenirVectorInicialitzacio()));
        }
    }
}
