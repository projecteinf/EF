# Expressions regulars
Utilitzem la classe estàtica Regex i el mètode IsMatch per a fer la validació d'una dada en relació a una expressió regular.  
```CSharp
// data: Informació que volem validar
// patró: Expressió regular que utilitzem per a validar data
if (Regex.IsMatch(data, patró)) {   
    // Compleix
} 
```


# Codi Exemple
```CSharp
using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Introdueix un número de telèfon: ");
        string telefon = Console.ReadLine();

        if (EsTelefonValid(telefon))
        {
            Console.WriteLine("✅ El número de telèfon és vàlid.");
        }
        else
        {
            Console.WriteLine("❌ El número de telèfon no és vàlid.");
        }
    }

    static bool EsTelefonValid(string telefon)
    {
        // Expressió regular per validar números de telèfon internacionals amb prefix de país
        string patró = @"^\+(\d{1,3})\s?\d{4,14}$";

        return Regex.IsMatch(telefon, patró);
    }
}
```
## Explicació del patró regex (@"^\+(\d{1,3})\s?\d{4,14}$")
* ^ → Inici de la cadena.
* \+ → El número ha de començar amb un + (prefix internacional).
* (\d{1,3}) → El prefix internacional pot tenir d’1 a 3 dígits (ex: +34, +1, +358).
* \s? → Pot haver-hi un espai opcional entre el prefix i el número.
* \d{4,14} → El número de telèfon pot tenir entre 4 i 14 dígits (sense tenir en compte guions o espais).
* $ → Final de la cadena.