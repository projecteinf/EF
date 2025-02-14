# 📌 Interfícies típiques en C#

| **Interfície**    | **Mètode(s)** | **Descripció** |
|------------------|--------------|---------------|
| `IComparable`   | `CompareTo(other)` | Defineix un mètode de comparació que un tipus implementa per ordenar o classificar les seves instàncies. |
| `IComparer`     | `Compare(first, second)` | Defineix un mètode de comparació que un segon tipus implementa per ordenar o classificar instàncies d'un tipus principal. |
| `IDisposable`   | `Dispose()` | Defineix un mètode de disposició per alliberar recursos no gestionats de manera més eficient que esperar un finalitzador. |
| `IFormattable`  | `ToString(format, culture)` | Defineix un mètode conscient de la cultura per formatar el valor d’un objecte en una representació de cadena. |
| `IFormatter`    | `Serialize(stream, object)` i `Deserialize(stream)` | Defineix mètodes per convertir un objecte cap i des d'un flux de bytes per a emmagatzematge o transferència. |
| `IFormatProvider` | `GetFormat(type)` | Defineix un mètode per formatar entrades segons un idioma i una regió. |

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