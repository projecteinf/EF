using System;
using System.Diagnostics;
using static System.Console;

class Program
{
    static void Main()
    {
        var nonGeneric = new PerformanceConsiderations();
        var genericInt = new GenericPerformanceConsiderations<int>();
        var genericBool = new GenericPerformanceConsiderations<bool>();

        Stopwatch sw = new Stopwatch();
        long nonGenericTotal = 0;
        long genericTotal = 0;

        
        for (int j = 0; j < 10; j++)
        {
            sw.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                nonGeneric.Process(42);
                nonGeneric.Process(true);
            }
            sw.Stop();
            nonGenericTotal += sw.ElapsedTicks; // Millor precisió amb Ticks

            sw.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                genericInt.Process(42);
                genericBool.Process(true);
            }
            sw.Stop();
            genericTotal += sw.ElapsedTicks;
        }

        Console.WriteLine("\nNon-generic time (avg): " + (nonGenericTotal / 10) + " ticks");
        Console.WriteLine("Generic time (avg): " + (genericTotal / 10) + " ticks");

        /*
            Non-generic time (avg): 12.462.058 ticks
            Generic time (avg): 11.822.749 ticks
        */
    }
}