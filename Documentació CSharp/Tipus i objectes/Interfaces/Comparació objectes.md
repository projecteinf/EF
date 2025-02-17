# Introducció

Quan fem una classe, és important definir quan dos objectes són iguals i quan un objecte és més gran que l'altre. La comparació és important, no tan sols per saber si 2 objectes són el mateix, si no per poder ordenar una llista d'objectes. Per exemple, si tenim una llista de persones, ens pot interessar ordenar-les per la seva edat. El mètode Sort (ordenar) utilitza la implementació de la comparació d'objectes per a la seva ordenació.

Per a comparar els objectes podem utilitzar 2 estratègies:
1. Implementar interfície IComparable.
2. Crear una nova classe.

## Utilitzant interfície IComparable

```CSharp
using System;

class Persona : IComparable<Persona>
{
    public string Nom { get; set; }
    public int Edat { get; set; }

    /// CompareTo retorna el resultat de restar els dos valors: this.Edat - altra.Edat
    /// Resultat: 0 => els dos valors són iguals
    /// <0 : el primer valor (this.Edat) és més petit
    /// >0 : el primer valor (this.Edat) és més gran 
    
    public int CompareTo(Persona? altra)    
    {
        if (altra == null) return 1;    // l'edat de les dues persones és diferent
        return this.Edat.CompareTo(altra.Edat);
    }
}
```

## Utilitzant una classe per a la comparació

A vegades no tenim accés al codi font de la classe sobre la qual volem aplicar la comparació.