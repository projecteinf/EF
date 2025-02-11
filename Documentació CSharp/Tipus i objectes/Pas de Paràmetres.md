# Pas de paràmetres - Overload

Dos mètodes amb el mateix nom però amb diferent número de paràmetres. Utilitzem aquesta tècnica per tal que la nostra classe sembli que tingui menys número de mètodes.

```CSharp
using System;
using static System.Console;

class Program
{
    static void Main()
    {
        PrintMessage();                      // Crida la versió sense paràmetres
        PrintMessage("Hola, món!");          // Crida la versió amb un string
        PrintMessage("Error", 3);            // Crida la versió amb un string i un int
    }

    static void PrintMessage()
    {
        WriteLine("Missatge per defecte.");
    }

    static void PrintMessage(string message) // Overload
    {
        WriteLine($"Missatge: {message}");
    }

    static void PrintMessage(string message, int times) // Overload
    {
        for (int i = 0; i < times; i++)
        {
            WriteLine($"[{i+1}] {message}");
        }
    }
}
```

1 mètode PrintMessage amb 3 variants!

# Paràmetres per defecte

```CSharp
using System;
using static System.Console;

class Program
{
    static void Main()
    {
        PrintMessage();                      // Crida la versió sense paràmetres
        PrintMessage("Hola, món!");          // Crida la versió amb un string
        PrintMessage("Error", 3);            // Crida la versió amb un string i un int
    }

    static void PrintMessage(string message = "Missatge per defecte.", int times = 1)
    {
        for (int i = 0; i < times; i++)
        {
            WriteLine($"[{i+1}] {message}");
        }
    }
}
```

# Pas de paràmetres

- Per valor - Entrada
- "out" - Només de sortida
- Per referència - Entrada i sortida