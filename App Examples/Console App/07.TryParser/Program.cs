using System;
using static System.Console;

// dotnet run 100 5,3

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: dotnet run <argument1> <argument2>");
            return;
        }


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
    }
}

