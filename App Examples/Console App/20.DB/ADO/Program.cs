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
            WriteLine($"Connexio {Connection.ConnectionDB}");
        }
    }
}