using System;
using static System.Console;

// dotnet run 100 5,3

class Program
{
    static int Main(string[] args)
    {
        if (args.Length != 2)
        {
            WriteLine("Usage: dotnet run <argument1> <argument2>");
            // dotnet run 100 5,3
            return 1;
        }

        WriteLine($"Type of args[0]: {args[0].GetType()}\nType of args[1]: {args[0].GetType()}");

        int price;
        if (int.TryParse(args[0], out price))
        {
            WriteLine($"The price is {price}€.");
        }
        else
        {
            WriteLine($"Conversion failed for: {args[0]}");
        }

        if (int.TryParse(args[1], out price))
        {
            WriteLine($"There are {price} products.");
        }
        else
        {
            WriteLine($"Conversion failed for: {args[1]}");
        }
        return 0;
    }
}

