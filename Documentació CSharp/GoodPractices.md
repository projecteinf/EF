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
