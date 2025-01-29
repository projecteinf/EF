# Nomenclatura de mètodes i propietats

## Mètodes

✅ Utilitza verbs 

**Exemple:**
```csharp
public class String {
    public int CompareTo(...);
    public string[] Split(...);
    public string Trim();
}
```

## Propietats

✅ Les propietats han de tenir noms que siguin **substantius, frases substantives o adjectius** per representar clarament les dades que emmagatzemen.

**Exemple:**
```csharp
// CORRECTE
public class Document {
    public string TextWriter { get {...} set {...} } 
} 
// INCORRECTE
public class Document {
    public string GetTextWriter(int value) { ... }
}
```

✅ Les propietats de col·leccions han de tenir un nom en plural que descrigui els elements de la col·lecció, en lloc d’afegir "List" o "Collection" al final del nom.

**Exemple:**
```csharp
// CORRECTE
public class Library
{
    public List<Book> Books { get; set; }
}

// INCORRECTE
public class Library
{
    public List<Book> BookList { get; set; }
}
```

✅ Les propietats booleanes han de tenir una frase afirmativa. Opcionalment, poden començar amb "Is", "Can" o "Has" si afegeix claredat.

**Exemple:**
```csharp
public class User
{
    public bool CanSeek { get; set; }   
    public bool IsActive { get; set; }  
    public bool HasSubscription { get; set; } 
}
```

