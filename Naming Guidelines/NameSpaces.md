# Guia de nomenclatura - Espai de noms

Aquest document inclou les recomanacions relacionades amb la nomenclatura dels espais de noms.

https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-namespaces

## Recomanacions

✔️ Els noms dels espais de noms han de ser significatius i descriptius.
✔️ Utilitzar la plantilla: <Company>.(<Product>|<Technology>)[.<Feature>][.<Subnamespace>] . Exemple: `Microsoft.Office.PowerPoint` , `Microsoft.VisualStudio.Xaml`, `Microsoft.VisualStudio.TestTools.UnitTesting`
✔️ Utilitzar noms d'espai de nom en plural si es considera un conjunt de classes. Exemple: `System.Collections`, `System.Collections.Generic` . Els noms de marca i les sigles són excepcions a aquesta regla. Per exemple: `System.IO` , `Microsoft.Office.PowerPoint` 
❌ No utilitzeu el mateix nom per a un espai de nom i un tipus en aquest espai de nom. Per exemple

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

