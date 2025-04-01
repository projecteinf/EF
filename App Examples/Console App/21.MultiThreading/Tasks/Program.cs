using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;


class Program {
    static void Main() {
        /* var timerSincron = Stopwatch.StartNew();
        WriteLine("Execució síncrona");
        MethodA();
        MethodB();
        MethodC();
        WriteLine($"Temps síncron: {timerSincron.ElapsedMilliseconds} ms"); */
        ExecuteAll();
        DependenciaExecucio();
    }
    static void DependenciaExecucio()
    {
        WriteLine("Passar el valor d'una tasca a una altra tasca");
        var taskGetProducts = Task.Factory.StartNew(CallWebService)
            .ContinueWith(
                previousTaks => 
                    CallStoreProcedure(previousTaks.Result)
            );
        WriteLine(taskGetProducts.Result);
    }

    static decimal CallWebService()
    {
        WriteLine("Crida a CallWebService iniciada");
        Thread.Sleep((new Random()).Next(2000,4000));
        WriteLine("Crida a CallWebService finalitzada");
        return 89.99M;
    }

    static string CallStoreProcedure(decimal amount)
    {
        WriteLine("Crida a Store Procedure. Obtenir dades de la base de dades a partir d'amount");
        Thread.Sleep((new Random()).Next(2000,4000));
        WriteLine("Crida a CallWebService finalitzada");
        return $"Productes: a,b,x,z amb preu superior a {amount}";
    }
    static void ExecuteAll() 
    {
        var timerParallel = Stopwatch.StartNew();
        WriteLine("Execució paral·lela");
        Task taskA = new Task(MethodA);
        taskA.Start();
        Task taskB = Task.Factory.StartNew(MethodB);
        Task taskC = Task.Run(new Action(MethodC));
        Task[] tasks = [ taskA, taskB, taskC];
        // Task.WaitAll(tasks);
        WriteLine($"Temps paral·lel: {timerParallel.ElapsedMilliseconds} ms");
        Task.WaitAll(tasks);
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
