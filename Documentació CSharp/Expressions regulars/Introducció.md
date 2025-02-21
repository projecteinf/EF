# Expressions regulars
Utilitzem la classe estàtica Regex i el mètode IsMatch per a fer la validació d'una dada en relació a una expressió regular.  
```CSharp
// data: Informació que volem validar
// patró: Expressió regular que utilitzem per a validar data
if (Regex.IsMatch(data, patró)) {   
    // Compleix
} 
```
# Símbols expressions regulars
| **Símbol**      | **Significat**                     | **Símbol**      | **Significat**                      |
|----------------|---------------------------------|----------------|----------------------------------|
| `^`           | Inici de la cadena             | `$`           | Final de la cadena              |
| `\d`          | Un sol dígit                   | `\D`          | Un sol caràcter NO numèric      |
| `\w`          | Caràcter alfanumèric o `_`     | `\W`          | Qualsevol caràcter NO alfanumèric |
| `[A-Za-z0-9]` | Rang(s) de caràcters           | `\^`          | El caràcter `^` literal        |
| `[aeiou]`     | Conjunt de caràcters (vocals)  | `[^aeiou]`    | Qualsevol caràcter que NO sigui vocal |
| `.`           | Qualsevol caràcter             | `\.`          | El caràcter `.` literal        |
| `+`         | Un o més              | `?`         | Un o cap         |
| `{N}`       | Exactament N       | `{N,M}`     | De N a M[¹] (ambdós inclosos)   |
| `{N,}`      | Com a mínim N      | `{,N}`      | Fins a N      |
[¹]: N i M són valors numèrics positius.

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
[+INFO sobre expressions regulars](https://www.regular-expressions.info)