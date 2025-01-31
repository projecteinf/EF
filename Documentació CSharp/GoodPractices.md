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