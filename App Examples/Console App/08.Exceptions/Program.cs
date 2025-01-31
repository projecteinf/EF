using System;
using static System.Console;

// dotnet run 100 

class Program
{
    static int Main(string[] args)
    {
        if (args.Length != 1)
        {
            WriteLine("Usage: dotnet run <argument1> <argument2>");
            return 1;
        }

        // EXECUCIÓ dotnet run 100 
        try 
        {
            int price = int.Parse(args[0]);
            WriteLine($"The price is {price}€.");
        }
        catch(Exception ex)     // Tots els errors
        {
            WriteLine($"{ex.GetType()} says {ex.Message}");
        }
        
        // Ordenar d'error més específic a més general. Ens permet mostrar un error més específic a l'usuari 

        // EXECUCIÓ dotnet run 5,3
        // EXECUCIÓ dotnet run 2147483648
        // EXECUCIÓ dotnet run string

        try 
        {
            int price = int.Parse(args[0]);
            WriteLine($"The price is {price}€.");
        }
        catch(FormatException ex)     // Errors de format
        {
            WriteLine($"Error de formateig {ex.GetType()} says {ex.Message}");
        }
        catch(OverflowException ex)     // Errors de desbordament
        {
            WriteLine($"Error de desbordament {ex.GetType()} says {ex.Message}");
        }
        catch(Exception ex)     // Tots els errors
        {
            WriteLine($"Error no controlat {ex.GetType()} says {ex.Message}");
        }
        
        return 0;
    }
}