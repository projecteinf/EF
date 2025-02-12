# Tipus i membres static

Mètodes d'instància són accions que intervenen sobre l'objecte. Els mètodes estàtics són accions que intervenen sobre el tipus.

Utilitzem tipus statics quan no és necessari crear objectes de la classe: tots els objectes comparteixen els mateixos valors pels camps i, per tant, no cal diferenciar-los entre ells.

Tots els membres d'una classe estàtica també han de ser estàtics.

## Exemple

En una aplicació podem definir els paràmetres per defecte del sistema utilitzant un tipus estàtic.

```CSharp
public static class SystemParameters { 
    public static string DefaultCurrency { get; set; } = "EUR";
    public static short NumberOfDecimals { get; set; } = "3";
    public static string FormatDate(DateTime date) {
        return date.ToString("yyyy-MM-dd");
    }
}
```

El membre FormatDate el podríem també definir en una classe Helper pròpia

```CSharp
public static class DateHelper {  
    public static string FormatDate(DateTime date) {
        return date.ToString("yyyy-MM-dd");
    }
}
```
# Mètodes statics i mètodes d'instància

Per a determinats mètodes, pot tenir sentit oferir la mateixa funcionalitat en un mètode static i un mètode d'instància. Per exemple, la classe string implementa dos mètodes per a comparar strings. CompareTo (mètode d'instància) i Compare (mètode estàtic). En classes pròpies, pot semblar que no té sentit, ja que, per exemple, si volem comparar dos objectes haurem de crear les instàncies dels objectes de totes formes. Podem pensar que no estalviem res. Però tenir un mètode estàtic per a comparar pot ser millorar la lectura del codi.

```CSharp
public static int Compare(Producte p1, Producte p2)
{
    return p1.Preu.CompareTo(p2.Preu);
}

Producte p1 = new Producte { Preu = 10 };
Producte p2 = new Producte { Preu = 20 };

int resultatEstatic = Producte.Compare(p1, p2); // Usant el mètode estàtic sense haver de crear una instància
int resultatInstancia = p1.CompareTo(p2);
```

Si volem comparar el preu d'una llista de productes, el codi es llegeix millor!

```CSharp
List<Producte> productes = new List<Producte> { p1, p2, p3 };
productes.Sort((x, y) => Producte.Compare(x, y)); // Usant el mètode estàtic per comparar
productes.Sort((x, y) => x.CompareTo(y));
```
És una bona pràctica, programar el mètode static i el d'instància amb l'objectiu de flexibilitar la reutilització del codi.
