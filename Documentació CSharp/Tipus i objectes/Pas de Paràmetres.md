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

- Per valor - Entrada. És el sistema utilitzat per defecte.
- "out" - Només de sortida. Utilitzem el modificador **out** abans de declarar el tipus de paràmetre
- Per referència - Entrada i sortida. Utilitzem el modificador **ref** abans de declarar el tipus de paràmetre

```CSharp

using System;
using static System.Console;

class Program {

    public static void ExemplePasParametres(int x, ref int y, out int? z)
    {
        
        // No podem referenciar a la z per què al no estar assignada 
        // el compilador no deixa compilar el programa

        WriteLine($"Dins el mètode: x = {x}, y = {y} z no es pot referenciar!!"); 
        
        z = 99; // Obligat inicialitzar el paràmetre out

        x++;
        y++;
        z++;
    }
    static void Main() {

        int a = 10;
        int b = 20;
        int? c = 30;

        WriteLine($"Abans: a = {a}, b = {b}, c = {c}");
        
        ExemplePasParametres(a, ref b, out c);
        
        WriteLine($"Després: a = {a}, b = {b}, c = {c}");
    }
}

/*** 

RESULTAT

Abans: a = 10, b = 20, c = 30
Dins el mètode: x = 10, y = 20 z no es pot referenciar!!
Després: a = 10, b = 21, c = 100

***/
```



