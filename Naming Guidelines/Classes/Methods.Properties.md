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
public class Person
{
    public string Name { get; set; }       // Substantiu
    public string FullAddress { get; set; } // Frase substantiva
    public bool Active { get; set; }       // Adjectiu
}

// ❌ Incorrecte (verbs no són adequats per a propietats)
public class Person
{
    public string GetName { get; set; }  // Sembla un mètode
}
```

