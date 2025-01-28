# Guia de nomenclatura - Espai de noms

Aquest document inclou les recomanacions relacionades amb la nomenclatura dels espais de noms.

https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-namespaces

## Recomanacions

✔️ Els noms dels espais de noms han de ser significatius i descriptius.

✔️ Utilitzar la plantilla: `<Company>.(<Product>|<Technology>)[.<Feature>][.<Subnamespace>]`  
**Exemple**:  `Microsoft.Office.PowerPoint` , `Microsoft.VisualStudio.Xaml`, `Microsoft.VisualStudio.TestTools.UnitTesting`

✔️ Utilitzar noms d'espai de nom en plural si es considera que l'espai de noms tindrà un conjunt de classes. 
** Exemple **: `System.Collections`, `System.Collections.Generic` .
Els noms de marca i les sigles són excepcions a aquesta regla. Per exemple: `System.IO` , `Microsoft.Office.PowerPoint` 

❌ No utilitzar el mateix nom per a un espai de nom i un tipus en aquest espai de nom. Per exemple

```csharp
namespace BoscComa.Api.Image
{
    public class Image
    {
        public Bitmap LoadBitmap(string filePath) { ... }
    }
}

namespace BoscComa.Api.Image
{
    public class Example
    {
        public Image LoadBitmap(string filePath) { ... }
    }
}
```

❌ No utilitzar noms genèrics com `Element`, `Node`, `Log` o `Message` perquè és molt probable que entrin en conflicte amb altres tipus en contextos comuns.

**Exemple:**
```csharp
// INCORRECTE:
public class Node { } // Podria entrar en conflicte amb System.Xml.XmlNode.

// CORRECTE:
public class XmlNodeWrapper { } // Afegeix context i evita conflictes.
```

❌ No duplicar noms de tipus dins d'un mateix model d'aplicació.

**Exemple:**
```csharp
// INCORRECTE: Duplicar noms dins del mateix model d'aplicació.
namespace System.Web.UI.Adapters {
    public class Page { } // Conflicte amb System.Web.UI.Page.
}

// CORRECTE: Evitar noms duplicats dins del mateix model.
namespace System.Web.UI.Adapters {
    public class CustomPageAdapter { }
}
```
❌ No utilitzis noms de tipus que entrin en conflicte amb namespaces del sistema core o més utilitzats (System.Collections, System.IO, System.Net, ...) 

**Exemple:**
```csharp
// INCORRECTE: Conflicte amb System.IO.Stream, tipus molt utilitzat.
public class Stream { } // 

// CORRECTE
public class CustomDataStream { }
```

❌ Conflictes entre tipus d'una mateixa tecnologia o entre tecnologia i models d'aplicació.

**Exemple:**
```csharp
// INCORRECTE: Duplicar noms dins de la mateixa tecnologia.
namespace Microsoft.Build.Utilities {
    public class Task { }
}

namespace Microsoft.Build.Tasks {
    public class Task { } // Conflicte amb Microsoft.Build.Utilities.Task.
}

// CORRECTE:
namespace Microsoft.Build.Utilities {
    public class BuildTaskUtilities { }
}

namespace Microsoft.Build.Tasks {
    public class BuildTask { }
}
```

