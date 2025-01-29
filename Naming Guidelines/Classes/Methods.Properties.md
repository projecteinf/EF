# Nomenclatura de mètodes i propietats

## Mètodes

✅ Utilitza verbs 

```csharp
public class String {
    public int CompareTo(...);
    public string[] Split(...);
    public string Trim();
}
```

## Propietats

✅ Les propietats han de tenir noms que siguin **substantius, frases substantives o adjectius** per representar clarament les dades que emmagatzemen.

```csharp
// ✅ Correcte
public class .... {
    public string TextWriter { get {...} set {...} } 
} 
// ❌ Incorrecte (verbs no són adequats per a propietats)
public class .... {
    public string GetTextWriter(int value) { ... }
}

```

