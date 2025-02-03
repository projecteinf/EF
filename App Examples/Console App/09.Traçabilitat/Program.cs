using System.Diagnostics;
using System.IO;

namespace Instrumenting
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new TextWriterTraceListener(File.CreateText("log.txt"))); // Emmagatzemart traces i depuracions en el fitxer log.txt    
            Trace.AutoFlush = true;
            Debug.WriteLine("Debug says, I am watching!");
            Trace.WriteLine("Trace says, I am watching!");
        }
    }
}

/* 
Execució: 
   dotnet run --configuration Release # Només s'escriuen els missatges de Trace
   dotnet run --configuration Debug # S'escriuen els missatges de Debug i Trace
   
*/