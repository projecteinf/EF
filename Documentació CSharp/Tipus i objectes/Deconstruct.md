# Deconstruct
Permet separar un objecte amb variables separades.
# Exemple
```CSharp
class Persona
{
    public string Nom { get; }
    public decimal Sou { get; }

    public Person(string nom, decimal sou)
    {
        Nom = nom;
        Sou = sou;
    }

    // Deconstruct method
    public void Deconstruct(out string nom, out int sou)
    {
        nom = this.Nom;
        sou = this.Sou;
    }
}

class Program
{
    static void Main()
    {
        Persona persona = new Persona("Anna", 1860);
        
        // Deconstruction
        (string personaNom, decimal personaSou) = persona;
        
        WriteLine($"{personaNom} cobra {personaSou} €."); 
    }
}
```
# Restriccions
* El mètode s'ha de dir **Deconstruct** per:  
    * En cas contrari no podem utilitzar l'operador = (tampoc hi ha la possibilitat de definir aquest operador)  
    * És un patró conegut en .NET. El nostre codi es llegeix de forma més fàcil.  