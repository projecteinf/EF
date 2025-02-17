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
A vegades no tenim accés al codi font de la classe sobre la qual volem aplicar la comparació. En aquests casos, no podem canviar la classe origen i implementar el mètode de comparació. L'opció que tenim és la de crear una classe específica per a implementar la comparació.

```CSharp
public class PersonaComparador : IComparer<Persona>
{
    public int Compare(Persona p1, Persona p2)
    {
        return p1.Edat - p2.Edat;
    }
}
```
Podem utilitzar una classe amb implementació de tipus <T>

```CSharp
public class PersonaComparador<T> : IComparer<Persona>
{
    private readonly Func<Persona, T> _criteri;     // Es tracta d'una funció delegada.
    private readonly bool _ordreInvers;

    public PersonaComparador(Func<Persona, T> criteri, bool ordreInvers = false)
    {
        _criteri = criteri;                         // Assignem el mètode get indicat per a l'usuari (main!)
        _ordreInvers = ordreInvers;
    }

    public int Compare(Persona p1, Persona p2)
    {
        int resultat = Comparer<T>.Default.Compare(_criteri(p1), _criteri(p2)); // Executa el mètode Get associat a la Funció Criteri. Funció delegada
        return _ordreInvers ? -resultat : resultat; // -resultat = (-1) * resultat -> Valor correcte per a canviar l'ordre
    }
}
```
Ens permet ordenar per a qualsevol camp de la classe.
## Utilitzant LINQ

