# Polimorfisme
En el document "Override vs New.md", el programa d'exemple mostra la sentència  
```CSharp
Persona persona = new Treballador();
```
Quina és la motivació d'aquesta sentència? Per què assignem a tipus Persona un objecte de tipus Treballador?
## Motivació
✅ Podem tractar totes les subclasses d'una classe (Persona en el nostre exemple) de manera homogènia.  
```csharp
    class Persona {
        ...
        public override string ToString() { .... }  
    }

    class Treballador : Persona {
        ...
        public override string ToString() { .... }  
    }

    class Jubilat : Persona {
        ...
        public override string ToString() { .... }  
    }

    List<Persona> persones = new List<Persona> {
        new Persona("Anna"),
        new Treballador("David", "17-3333213-21"),
        new Jubilat("Eva", "Pensió mínima")
    };

    foreach (var p in persones)
    {
        Console.WriteLine(p.ToString()); // Si està sobreescrit amb override, crida el de Treballador quan toca
    }
``` 
✅ Sabem l'objecte fill en temps d'execució. Tots els objectes fill poden ser associats a la classe pare.  
```CSharp
    Persona persona;

    if (esTreballador) {
        persona = new Treballador("Maria", "99-9876543-21");
    } else {
        persona = new Persona("Joan");
    }
    Console.WriteLine(persona.ToString()); // Executarà el correcte gràcies a override
```
✅  Volem encapsulació i flexibilitat. Podem facilitar la inclusió de més subclasses en el futur.
```CSharp
enum TipusPersona { Persona, Treballador, Jubilat } 

Persona CreaPersona(TipusPersona tipus, string nom, string? nss = null)
{
    return tipus switch
    {
        TipusPersona.Treballador => new Treballador(nom, nss),
        TipusPersona.Jubilat => new Jubilat(nom),
        _ => new Persona(nom) // Per defecte
    };
}
```
Nota: Mirar patró Factory (Factory.md)