using System.Diagnostics;
using System.IO;


/*
Punts importants a recordar:

    Listeners compartits: Un cop afegits a Trace.Listeners, els listeners s'utilitzen globalment a tota l'aplicació.
    Tots els listeners reben els missatges: Quan fas Trace.WriteLine(), tots els listeners existents escriuen el missatge.
    Trace.AutoFlush: Assegura que els missatges s'escriguin immediatament al fitxer (sense necessitat d'un Flush() manual).
    Listeners per defecte: Si no afegeixes cap listener, per defecte, .NET només escriu els logs a la sortida de depuració.

Execució: 
   dotnet run --configuration Release # Només s'escriuen els missatges de Trace
   dotnet run --configuration Debug # S'escriuen els missatges de Debug i Trace

TRACE SWITCH


0    Off          This will output nothing
1    Error        This will output only errors
2    Warning      This will output errors and warnings
3    Info         This will output errors, warnings, and information
4    Verbose      This will output all levels

*/


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

