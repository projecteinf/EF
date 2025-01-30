# Nomenclatura per propietats de recursos (resources)

✅ Utilitza PascalCasing (la primera lletra de cada paraula en majúscula) per a les claus de recursos.

```csharp
// Fitxer de recursos: Resources.resx
// CORRECTE
GreetingMessage = "Hello, World!";

// INCORRECTE
greeting_message = "Hello, World!";
```

✅ Utilitza identificadors descriptius en lloc de noms curts o críptics.

```csharp
// Fitxer de recursos (Resources.resx)
// CORRECTE
FileNotFoundMessage = "File not found.";

// INCORRECTE
msg1 = "File not found.";
```
✅ Evita utilitzar paraules reservades dels llenguatges principals de .NET (com C#, VB.NET, etc.) com a claus de recursos.

```csharp
// Fitxer de recursos (Resources.resx)
// CORRECTE
Classroom = "Classroom";

// INCORRECTE
class = "Classroom";
```

✅ Utilitza només caràcters alfanumèrics i subratllats (_) per a les claus de recursos.

```csharp
// Fitxer de recursos (Resources.resx)
// CORRECTE
UserName = "John Doe";

// INCORRECTE
user-name = "John Doe";
```

✅ Utilitza una convenció específica per als missatges d'excepció. Normalment, es recomana incloure el tipus d'excepció o el context en el nom de la clau.

```csharp
// Fitxer de recursos (Resources.resx)
// CORRECTE - les claus de recursos són descriptives i inclouen el tipus d'excepció o el context
FileNotFoundExceptionMessage = "The file was not found.";
ArgumentNullExceptionMessage = "Value cannot be null.";

// INCORRECTE
error = "An error occurred.";
```
