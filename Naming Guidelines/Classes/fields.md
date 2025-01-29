# Nomenclatura de camps (fields)

✅ Els noms dels camps han d'utilitzar **PascalCasing** .

**Exemple:**
```csharp
// CORRECTE
public class Usuari
{
    public string FullName;
    public int Age;
}
```

✅ Els camps han de tenir noms que siguin substantius, frases substantives o adjectius.

**Exemple:**
```csharp
// CORRECTE

public class Configuration
{
    public string FilePath;  
    public bool Active;        
}
```

❌ No utilitzis prefixos en els noms dels camps.

**Exemple:**
```csharp
// CORRECTE
public class Person
{
    public string Name;  
    public int Age;    
}

// INCORRECTE

public class Person
{
    public string m_Name;  
    public int _Age;
}

