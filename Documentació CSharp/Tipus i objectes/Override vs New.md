# Introducció
En la herència d'una classe, podem definir mètode amb el mateix nom i signatura entre la classe pare i fill. Per fer-ho disposem de dues opcions: override i new.  
# Característiques d'override i new
| **Característica**                            | `override` | `new` |
|-----------------------------------------------|-----------|-------|
| Requereix `virtual` a la classe base         | ✅ Sí     | ❌ No  |
| Substitueix el mètode base?                   | ✅ Sí     | ❌ No, només l’oculta |
| Permet polimorfisme?                          | ✅ Sí     | ❌ No  |
| Es crida des d’una referència de la base?     | ✅ Executa el de la classe derivada | ❌ Executa el de la base |
# Codi exemple de funcionament
```CSharp
public class Persona {
    public string Name { get; set; }
    public Persona(string name) {
        this.Name = name;
    }

    // Signatura ToString de la classe Object: public virtual string? ToString();
    public override string ToString() {
        return $"Override ToString() of class Object {this.Name}";
    }
    public virtual string? ToStringNew() {
        return $"ToStringNew() of class Persona {this.Name}";
    }
}

class Treballador : Persona {
    public string NSS {get; set;}
    public Treballador(string name,string nss) : base(name) { // Crida al constructor pare (Persona)
        this.NSS = nss;
    }
    public override string ToString() {
        return $"Override ToString() of class Persona {this.NSS}";
    }

    public new string? ToStringNew() {
        return $"ToStringNew() of class Treballador {this.NSS}";
    }
}

using System;
using static System.Console;

class Program {
    static void Main() {
        Persona persona = new Persona("Anna");
        WriteLine(persona.ToString());  
        WriteLine(persona.ToStringNew());  
        WriteLine("----------------------------------------------------------------------------");

        Treballador treballador = new Treballador("David", "17-3333213-21");
        WriteLine(treballador.ToString());  
        WriteLine(treballador.ToStringNew());  
        WriteLine("----------------------------------------------------------------------------");

        Persona refPersona = new Treballador("Eva", "98-1234567-89"); 
        WriteLine(refPersona.ToString());  
        WriteLine(refPersona.ToStringNew());  
    }
}
```
## Resultat execució
```
Override ToString() of class Object Anna
ToStringNew() of class Persona Anna
----------------------------------------------------------------------------
Override ToString() of class Persona 17-3333213-21
ToStringNew() of class Treballador 17-3333213-21
----------------------------------------------------------------------------
Override ToString() of class Persona 98-1234567-89
ToStringNew() of class Persona Eva
```
ToStringNew() of class Persona Eva => Tot i que "Eva" és creat com a objecte Treballador, la crida és del mètode ToStringNew() de Persona . L'utilització de new no permet la sobreescritura. Normalment, no és el comportament desitjat. El comportament desitjat és el del mètode ToString().  
