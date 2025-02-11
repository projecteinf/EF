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
# Documentació sobre funcions

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
