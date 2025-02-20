# Mètodes d'extensió
Utilitzem un mètode d'extensió quan volem afegir funcionalitat a una classe que no podem modificar (sealed) o no volem modificar. Per exemple, la classe "string" està optimitzada i sealed per evitar que ningú la pugui "destrossar"! . Per afegir funcionalitat a aquesta classe hem de crear mètodes d'extensió.
# Creació d'un mètode d'extensió
✅ La classe s'ha de definir com a "static".  
✅ El mètode s'ha de definir com a "static".  
✅ El primer paràmetre ha de ser "this".  
## Codi Exemple amb tipus string
```CSharp
using System;
using static System.Console;

public static class StringExtensions
{
    public static string CapitalizeFirstLetter(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        return char.ToUpper(input[0]) + input.Substring(1);
    }
}

class Program
{
    static void Main()
    {
        string text = "hola, món!";
        string capitalizedText = text.CapitalizeFirstLetter(); 

        WriteLine(capitalizedText); // Sortida: "Hola, món!"
    }
}
```
public static string CapitalizeFirstLetter(this string input)
| **Part**               | **Funció** |
|------------------------|------------|
| `public static`        | El mètode ha de ser `static` perquè els mètodes d’extensió no pertanyen realment a la classe `string`, sinó que s'hi afegeixen externament. |
| `string`              | El tipus de retorn (`string` en aquest cas). |
| `CapitalizeFirstLetter` | El nom del mètode. |
| `this string input`   | Aquí `this` indica que aquest mètode s’aplica a la classe `string`, i `input` és el nom del paràmetre que representa l'objecte `string` sobre el qual s'està cridant el mètode. |
## Codi exemple amb classe pròpia
```CSharp
public class Persona
{
    public string Nom { get; set; }
    public string Ocupacio { get; set; }
}

public static class PersonaExtensions
{
    public static bool EstaTreballant(this Persona persona) // Actua sobre objectes de classe Persona
    {
        return !string.IsNullOrEmpty(persona.Ocupacio);
    }
}

using System;
using static System.Console;

class Program
{
    static void Main()
    {
        Persona p1 = new Persona { Nom = "Joan", Ocupacio = "Enginyer" };
        Persona p2 = new Persona { Nom = "Maria", Ocupacio = "" };

        WriteLine($"{p1.Nom} està treballant? {p1.EstaTreballant()}"); // Sortida: Joan està treballant? True
        WriteLine($"{p2.Nom} està treballant? {p2.EstaTreballant()}"); // Sortida: Maria està treballant? False
    }
}
```