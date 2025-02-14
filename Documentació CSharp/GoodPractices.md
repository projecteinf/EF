# Ús de _var_
Només podem utilitzar _var_ per a declarar variables locals quan el tipus de la variable és evident pel context. Per exemple, en el següent exemple, és evident que _i_ és un enter:
```csharp
// CORRECTE
var invoice = new XmlDocument();
XmlDocument invoice = new XmlDocument(); // Tot i que correcte, és redundant especificar el tipus

// INCORRECTE
var productSpecification = File.CreateText(@"./productSpecification.dat");  // No podem deduir el tipus de la variable StreamWriter productSpecification = File.CreateText(@"./productSpecification.dat");
```
# Sentències if
Utilitzar sempre { } encara que la sentència if només tingui una línia de codi: millora la llegibilitat del codi i evita possibles errors.
```csharp
// Mala pràctica - tot i que funciona
if (condition)
    sentencia

if (condition) sentencia

// Bona pràctica
if (condition)
{
    // codi
}
```
# Arrodoniment de valors numèrics
Verificar en qualsevol llenguatge que utilitzeu com funciona l'arrodoniment i conversió dels valors numèrics
# Fitxers binaris
Si has d'enviar per la xarxa o guardar en disc fitxers binaris, has de tenir en compte que el sistema de fitxers pot interpretar els caràcters de control com a caràcters especials. Per això, és recomanable codificar els fitxers binaris en base64.
```csharp
using System;
using static System.Console;

byte[] binaryObject = new byte[128];

(new Random()).NextBytes(binaryObject); // Omplim l'array amb valors (bytes) aleatoris

WriteLine("Binary Object as bytes\n");
for(int index = 0; index < binaryObject.Length; index++)
{
    Write($"{binaryObject[index]:X} ");
}
WriteLine();

string encoded = Convert.ToBase64String(binaryObject);
WriteLine($"Binary Object as Base64\n {encoded}");
```
# Documentació sobre funcionGood Practice: Having both the static and instance methods to
perform similar actions often makes sense. For example, string
has both a Compare static method and a CompareTo instance
method. This puts the choice of how to use the functionality in
the hands of the programmers using your type, giving them more
flexibility.s

Utilitzem /// per a tenir l'estructura bàsica que ens servirà per a documentar les funcions.
# Registre d'errors i traçabilitat
Afegeix un sistema de registre (Logging) a la teva aplicació per a poder determinar què ha passat en cas d'error. Això et permetrà identificar i solucionar problemes més ràpidament.
Utilitza traçabilitat en les operacions rellevants de la teva aplicació: emmagatzematge de dades a la base de dades, flux de treball, etc.
# Enumerables
Utilitza valors enum per a emmagatzemar combinacions d'opcions discretes. El tipus del camp enum depèn del nombre de valors discrets o opcions que pot emmagatzemar la variable:
- 8 opcions -> byte 
- 16 opcions -> short 
- 32 opcions -> int
- 64 opcions -> long
# Constants i read-only
Cal prioritzar l'ús de variables o membres de tipus read-only sobre l'utilització de contants.
# Tuples
Sempre que retornem una tupla, els seus camps seran nominals, significatius i seguiran la nomenclatura definida pels camps associats a tipus.
# Properties vs Fields
Utilitza propietats enlloc de camps quan vols validar els valors que poden ser emmagatzemats.
# Mètodes statics i d'instància
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
# Estructura de les classes de l'aplicació 
- Agruparem les classes en directoris que indicaran la funcionalitat de les mateixes: Interfaces, View, Controller, Model,...
- El nom de la classe i del fitxer ha de ser el mateix (sense la extensió del fitxer).
- Normalment tindrem un fitxer per a cada classe. Una excepció pot ser en els casos que s'utilitzin DTO.
# Operadors definits en tipus
Sempre que definim un operador, definirem també un segon mètode que implementi l'operador. L'usuari podrà utilitzar qualsevol dels dos, però la definició d'un mètode permet que la funcionalitat estigui disponible a IntelliSense.
# Gestió d'events amb delegats
# Delegats predefinits
Sempre utilitzarem un d'aquests dos delegats en la gestió d'events.
```CSharp
public delegate void EventHandler(object sender, EventArgs e);
public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
```
