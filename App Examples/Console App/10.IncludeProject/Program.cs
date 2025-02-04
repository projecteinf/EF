using System;
using static System.Console;
using Calc = BoscComa.Calculadora.Calculadora;  // Using alias directive. El nom de l'espai de noms i el de la classe coincideixen i el compilador no sap diferenciar l'un de l'altre.

namespace BoscComa.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BoscComa.Calculadora.Calculadora calc = new Calc();
            WriteLine(calc.Sumar(1, 2));
        }
    }
}

