using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;


class Program {
    static void Main() {
        var timer = Stopwatch.StartNew();
        WriteLine("Execució síncrona");
        MethodA();
        MethodB();
        MethodC();
        WriteLine($"Temps síncron: {timer.ElapsedMilliseconds} ms");
    }
    static void MethodA()
    {
        WriteLine("Iniciat mètode A");
        Thread.Sleep(3000);
        WriteLine("Finalitzat mètode A");
    }
    static void MethodB()
    {
        WriteLine("Iniciat mètode B");
        Thread.Sleep(2000);
        WriteLine("Finalitzat mètode B");
    }
    static void MethodC()
    {
        WriteLine("Iniciat mètode C");
        Thread.Sleep(1000);
        WriteLine("Finalitzat mètode C");
    }
}
