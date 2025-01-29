# Nomenclatura de Clases, Interfaces y Structs

✅ El nom de la classe i de l'estructura ha de descriure l'entitat o objecte que representa. Utilitza substantius com a element principal i adjectius com a complement. 

**Exemple:**
```csharp
// CORRECTE
public class CustomerAccount { } // Frase substantiva: "Customer Account"
public struct OrderDetails { }   // Frase substantiva: "Order Details"
public class ProductCatalog { }  // Frase substantiva: "Product Catalog"

// CORRECTE (amb adjectius afegits al substantiu)
public class ActiveCustomer { }  // Substantiu "Customer" amb adjectiu "Active"
public struct PendingOrder { }   // Substantiu "Order" amb adjectiu "Pending"

// INCORRECTE
public class Calculate { }       // Verbs com a nom de classe no són adequats.
public struct Update { }         // Verbs com a nom d'estructura tampoc són adequats.
```

✅ Els noms d'interfícies han de ser frases adjectivals ( l'adjectiu és el nucli ) o, ocasionalment, frases substantives. Cal tenir en compte que les interfícies descriuen una qualitat, comportament o estat de les classes implementen.

**Exemple:**
```csharp
// CORRECTE
public interface IPersistable { } // Frase adjectival
public interface ICustomAttributeProvider { } // Frase substantiva

// INCORRECTE
public interface Persistable { } // No té el prefix "I"
```


✅ Prefixa els noms de les interfícies amb la lletra I per indicar clarament que són interfícies.

**Exemple:**
```csharp
// CORRECTE
public interface IComponent { }
public interface IPersistable { }

// INCORRECTE
public interface Component { } // Falta el prefix "I"
```

✅ Quan defineixis una parella classe-interfície, assegura't que només es diferencien pel prefix "I".

**Exemple:**
```csharp
// CORRECTE
public interface ICustomer { }
public class Customer : ICustomer { }

// INCORRECTE
public interface ICustomer { }
public class Client : ICustomer { } // Nom no consistent amb la interfície
```

✅ Les classes i estructures han de tenir noms amb substantius o frases substantives.

**Exemple:**
```csharp
// CORRECTE
public class CustomerAccount { }
public struct OrderDetails { }

//  INCORRECTE
public class customeraccount { }
public struct orderdetails { }
```

✅ Incloure el nom de la classe base al final del nom de la classe derivada


**Exemple:**
```csharp
// CORRECTE
public class ArgumentOutOfRangeException : Exception { }
public class SerializableAttribute : Attribute { }

// INCORRECTE
public class OutOfRange : Exception { } // No acaba amb "Exception"
```

❌ No prefixis noms de classes amb lletres com "C".

**Exemple:**
```csharp
// CORRECTE
public class Customer { }
public class Order { }

// INCORRECTE
public class CCustomer { }
public class COrder { }
```



