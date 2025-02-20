# Base
"base" és una paraula clau que ens permet referenciar a la classe pare des d'una classe fill. Excepte en el constructor, utilitzem base i el nom del mètode o propietat de la classe pare que volem referenciar.
## Exemple d'ús
```CSharp
public class Persona {
    public string Name { get; set; }
    public Persona(string name) 
    {
        this.Name = name;
    }
    public override string ToString() 
    {
        return $"{this.Name}";
    }    
}

class Treballador : Persona {
    public string NSS {get; set;}
    public Treballador(string name,string nss) : base(name) // Crida al constructor pare (Persona)
    { 
        this.NSS = nss;
    }
    public override string ToString() 
    {
        return $"Pare: {base.ToString()}\nFill: {this.NSS}";    // Referència al mètode ToString de la classe Persona
    }
}
```